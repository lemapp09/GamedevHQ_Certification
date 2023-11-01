﻿using System;
using System.Collections;
using System.Collections.Generic;
using MetroMayhem.Enemies;
using MetroMayhem.Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace MetroMayhem.Weapons
{
    #region message
    /// <summary>
    /// This script will allow you to view the presentation of the Turret and use it within your project.
    /// Please feel free to extend this script however you'd like. To access this script from another script
    /// (Script Communication using GetComponent) -- You must include the namespace (using statements) at the top. 
    /// "using GameDevHQ.FileBase.Dual_Gatling_Gun" without the quotes. 
    /// 
    /// For more, visit GameDevHQ.com
    /// 
    /// @authors
    /// Al Heck
    /// Jonathan Weinberger
    /// </summary>
    #endregion
    [RequireComponent(typeof(AudioSource))] //Require Audio Source component
    public class Dual_Gatling_Gun : MonoBehaviour , IWeapon
    {
        #region variables
        [SerializeField] private Transform[] _firePoint; // Where bullets are instantiated
        [SerializeField] private Transform[] _gunBarrel; //Reference to hold the gun barrel

        [SerializeField] private GameObject[] _muzzleFlash; //reference to the muzzle flash effect to play when firing

        [SerializeField]
        private ParticleSystem[] _bulletCasings; //reference to the bullet casing effect to play when firing

        [SerializeField] private GameObject _bulletPrefab; //reference to the bullet prefab to instantiate
        [SerializeField] private AudioClip _fireSound; //Reference to the audio clip

        [SerializeField] private AudioMixerGroup _mixerGroup;
        private AudioSource _audioSource; //reference to the audio source component
        private bool _startWeaponNoise = true;
        private MetroMayhemInputSystem _input;

        public float viewRange = 5f;
        public float viewAngle = 90f;
        public LayerMask targetMask;
        public LayerMask obstacleMask;
        public List<Transform> visibleTargets = new List<Transform>();

        private bool _isFiring;
        private bool _isPaused;
        private int _platformID;
        [SerializeField] private int _weaponID;
        private int _damageAmount;
        private float _tempRotY;
        private float _health = 100;
        #endregion
        
        private void OnEnable()
        {
            _isPaused = true;
            _input = new MetroMayhemInputSystem();
            _input.Towers.Enable();
            _tempRotY= transform.localRotation.eulerAngles.y;
            GameManager.StartLevel += PauseGun;
            GameManager.StartPlay += UnpauseGun;
            GameManager.PauseLevel += PauseGun;
            GameManager.UnpauseLevel += UnpauseGun;
            GameManager.StopLevel += PauseGun;
            GameManager.RestartLevel += PauseGun;
        }

        void Start()
        {
            _muzzleFlash[0].SetActive(false); //setting the initial state of the muzzle flash effect to off
            _muzzleFlash[1].SetActive(false); //setting the initial state of the muzzle flash effect to off
            _audioSource = GetComponent<AudioSource>(); //ssign the Audio Source to the reference variable
            _audioSource.playOnAwake = false; //disabling play on awake
            _audioSource.loop = true; //making sure our sound effect loops
            _audioSource.clip = _fireSound; //assign the clip to play
            _audioSource.outputAudioMixerGroup = _mixerGroup;
            // StartCoroutine("FindVisibleTargets");
        }

        // Update is called once per frame
        void Update()
        {
            if (!_isPaused)
            {
                if (_isFiring) //Check for left click (held) user input
                {
                    Debug.Log("Is Firing!");
                    RotateBarrel(); //Call the rotation function responsible for rotating our gun barrel

                    //for loop to iterate through all muzzle flash objects
                    for (int i = 0; i < _muzzleFlash.Length; i++)
                    {
                        _muzzleFlash[i].SetActive(true); //enable muzzle effect particle effect
                        _bulletCasings[i].Emit(1); //Emit the bullet casing particle effect  
                        FireBullet(i);
                    }

                    if (_startWeaponNoise == true) //checking if we need to start the gun sound
                    {
                        _audioSource.Play(); //play audio clip attached to audio source
                        _startWeaponNoise =
                            false; //set the start weapon noise value to false to prevent calling it again
                    }
                }
                else if (!_isFiring) //Check for left click (release) user input
                {
                    //for loop to iterate through all muzzle flash objects
                    for (int i = 0; i < _muzzleFlash.Length; i++)
                    {
                        _muzzleFlash[i].SetActive(false); //enable muzzle effect particle effect
                    }

                    _audioSource.Stop(); //stop the sound effect from playing
                    _startWeaponNoise = true; //set the start weapon noise value to true
                }
            }
        }

        private void FireBullet(int i)
        {
            // Instantiate(_bulletPrefab, _firePoint[i].position, _firePoint[i].rotation); //instantiate the bullet prefab
            // Raycast forward to see what object(s) the bullet will hit
            RaycastHit hit;
            if (visibleTargets.Count > 0)
            {
                Vector3 direction = visibleTargets[i].position -
                                    visibleTargets[Random.Range(0, visibleTargets.Count - 1)].position;
                if (Physics.Raycast(_firePoint[i].position, direction, out hit))
                {
                    DamageEnemy(hit);
                }
            }
            else
            {
                if (Physics.Raycast(_firePoint[i].position, _firePoint[i].forward, out hit))
                {
                    DamageEnemy(hit);
                }
            }
        }

        private void DamageEnemy(RaycastHit hit)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.collider.SendMessage("Damage", 35);
            }
        }
        public void Damage(int DamageAmount)
        {
            _health -= DamageAmount;
            if (_health < 0) {
                Destroy(gameObject);
            }
        }

        public void Rotate(bool rotateLeft) {
            if (rotateLeft) {
                _tempRotY -= 15f;
            } else  {
                _tempRotY += 15f;
            }

            if (_tempRotY <= 0) {
                _tempRotY = 0;}
            else if (_tempRotY >= 360) {
                _tempRotY = 360;
            }
            transform.localRotation = Quaternion.Euler(0, _tempRotY, 0);
        }

        // Method to rotate gun barrel 
        void RotateBarrel()
        {
            _gunBarrel[0].transform
                .Rotate(-500.0f * Time.deltaTime *
                        Vector3.forward); //rotate the gun barrel along the "forward" (z) axis at 500 meters per second
            _gunBarrel[1].transform
                .Rotate(-500.0f * Time.deltaTime *
                        Vector3.forward); //rotate the gun barrel along the "forward" (z) axis at 500 meters per second
        }

        private void OnMouseDown() {
            _isFiring = true;
        }

        private void OnMouseUp() {
            _isFiring = false;
        }

        private void OnMouseDrag()
        {
            //
        }

        private void OnDisable()
        {
            GameManager.StartLevel -= PauseGun;
            GameManager.StartPlay -= UnpauseGun;
            GameManager.PauseLevel -= PauseGun;
            GameManager.UnpauseLevel -= UnpauseGun;
            GameManager.StopLevel -= PauseGun;
            GameManager.RestartLevel -= PauseGun;
        }

        private void PauseGun()
        {
            _isPaused = true;
        }

        private void UnpauseGun()
        {
            _isPaused = false;
        }

        IEnumerator FindVisibleTargets()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);
                FindTargetsInView();
            }
        }

        void FindTargetsInView()
        {
            visibleTargets.Clear();
            Collider[] targetsInView = Physics.OverlapSphere(transform.position, viewRange, targetMask);

            for (int i = 0; i < targetsInView.Length; i++)
            {
                Transform target = targetsInView[i].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                    {
                        visibleTargets.Add(target);
                    }
                }
            }
        }
    }
}