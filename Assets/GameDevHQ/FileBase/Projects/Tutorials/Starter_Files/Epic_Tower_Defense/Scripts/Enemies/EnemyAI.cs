﻿using System.Collections;
using System.Collections.Generic;
using HoaxGames;
using MetroMayhem.Manager;
using UnityEngine;
using UnityEngine.Audio;
using ProjectDawn.Navigation.Hybrid;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace MetroMayhem.Enemies
{
    [RequireComponent(typeof(FootIK))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    
    public class EnemyAI : MonoBehaviour
    {
        #region Variables
        [Header("NavMesh Agent")]
        [SerializeField] private AgentAuthoring _agent;
        private List<Transform> _waypoints;
        [SerializeField] private int _currentWayPointIndex = 0;
        
        [Header("Animator")]
        [SerializeField] private Animator _anim;
        [SerializeField] private float _maxSpeed = 1.5f;
        
        [Header("Audio")]
        [SerializeField] private AudioMixerGroup _mixerGroup;
        private AudioSource _audioSource;
        
        [Header("Dissolve")]
        [Tooltip("Time in seconds for full dissolve")]
        [SerializeField] private float _dissolveSpeed; // 10 for Large, 3 for small
        [SerializeField] private Material _DissovleMaterial;
        public float _dissolveAmount = 1.0f;
        
        [Header("Health")]
        [SerializeField] private float _health = 100f;
        
        private bool _isHit, _isDead, _isPaused;
        private int _idlesHash, _hitsHash, _deathsHash, _idealNumberHash, _deathHash, _hitHash, _speedHash,
            _dissolveAmmountID;

        private float _speedCheckTimer = 0f, _speedCheckInterval = 0.1f;
        private float _unfreezeCharacter = 0f, _unfreezeInterval = 1.0f;
        private Vector3 _unfreePosition;

        public delegate void EnemyReachedDestination();
        public static event EnemyReachedDestination EnemySurvived;
        public delegate void EnemyWasKilled();
        public static event EnemyWasKilled EnemyKilled;
        #endregion
        
        private void OnEnable() {
            Manager.GameManager.PauseLevel += Pause;
            Manager.GameManager.UnpauseLevel += Unpause;
            Manager.GameManager.StopLevel += Pause;
            InitializeVariables();
        }
        
        void Start() {
            // Get the NavMeshAgent and Animator components
            _agent = GetComponent<AgentAuthoring>();
            _anim = GetComponent<Animator>();
            if (_waypoints.Count == 0) {
               Debug.Log("There are no Waypoints!");
            }
            
            // Initialize
            _anim.SetFloat(_idealNumberHash, Random.Range(0, 11) * 0.1f);
            // Assign the initial destination for the NavMeshAgent
            _agent.SetDestination(_waypoints[_currentWayPointIndex].transform.position);
            StartCoroutine(CheckDistance());
            // Dissolve Initialize
            if (_dissolveSpeed > 0) {
                _dissolveSpeed = 1 / _dissolveSpeed;
            }
            _dissolveAmmountID = Shader.PropertyToID("_DissolveAmount");
            InitializeAudioSource();
        }

        public void PopulateWaypoints(List<Transform> waypoints) {
            _waypoints = waypoints;
            _currentWayPointIndex = 0;
        }

        public void InitializeVariables() {
            _currentWayPointIndex = 0;
            _isHit = false; _isDead = false; _isPaused = false;
            _speedCheckTimer = 0f; _speedCheckInterval = 0.1f;
            _unfreezeCharacter = 0f; _unfreezeInterval = 1.0f;
            _unfreePosition = Vector3.zero;
        }

        private void Unpause() { 
            // _agent Start
            _agent.SetDestination(_waypoints[_currentWayPointIndex].position);
        }

        private void Pause() {
            _agent.SetDestination(this.transform.position);
        }
        
        void Update() {
            _speedCheckTimer += Time.deltaTime;
            _unfreezeCharacter += Time.deltaTime;
            if (_speedCheckTimer >= _speedCheckInterval) {
                if (!_isHit && !_isDead) {
                    // Get the velocity of the NavMeshAgent and set the Speed parameter of the Animator
                    float3 speed1 = _agent.EntityBody.Velocity;
                    Vector3 vector = new Vector3(speed1.x, speed1.y, speed1.z);
                    _anim.SetFloat(_speedHash, vector.magnitude);

                    // Rotate the enemy to face the direction of travel
                    if (-vector.sqrMagnitude > Mathf.Epsilon) {
                        transform.rotation = Quaternion.LookRotation(vector.normalized);
                    }
                }
            }
            if(_unfreezeCharacter >= _unfreezeInterval) {  // Check every second to start a frozen character
                UnFreezeEnemy();
            }
        }

        private void UnFreezeEnemy() {
            if (!_isHit && !_isDead && _unfreePosition == this.transform.position) {
                _agent.SetDestination(_waypoints[_currentWayPointIndex].position);  
            }
            _unfreezeCharacter = 0f;
            _unfreePosition = this.transform.position;
        }
        
        public void Damage(int amount) {
            if (!_isHit) {
                _audioSource.clip = AudioManager.Instance.PlayHurtSound();
                _audioSource.Play();
                _isHit = true;
                _health -= amount;
                _agent.SetDestination(this.transform.position);
                _anim.SetTrigger(_hitHash);
                if (_health < 1) {
                    Death();
                }
            }
        }

        private void Death() {
            _audioSource.clip = AudioManager.Instance.PlayDeathSound();
            _audioSource.Play();
            EnemyKilled?.Invoke();
            _isDead = true;
            _agent.SetDestination(this.transform.position);
            _anim.SetTrigger(_deathHash);
            _agent.enabled = false;
        }

        IEnumerator HitRoutine() {
            _agent.SetDestination(this.transform.position);
            yield return new WaitForSeconds(1.5f);
            _agent.SetDestination(_waypoints[_currentWayPointIndex].position);
        }
        
        private IEnumerator  CheckDistance() {
            while (_currentWayPointIndex < _waypoints.Count - 1) {
                while (Vector3.Distance(transform.position, _waypoints[_currentWayPointIndex].position) > 1f) {
                    yield return new WaitForSeconds(0.1f);
                }
                _currentWayPointIndex++;
                Vector3 tempPosition = _waypoints[_currentWayPointIndex].position;
                tempPosition = new Vector3(tempPosition.x + Random.Range(-1.0f, 1.0f), transform.position.y,
                    tempPosition.z+ Random.Range(-1.0f, 1.0f));
                _agent.SetDestination(tempPosition);
            }
            EnemySurvived?.Invoke();
            PoolManager.Instance.ReturnToPool(this.gameObject);
        }

        public void OnAnimationStateEntered(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.shortNameHash == _deathsHash) {
                StartCoroutine(DissolveEnemy(stateInfo.length));
            }
        }

        public void OnAnimationStateExited(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.shortNameHash == _hitsHash) {
               _isHit = false;
               _agent.SetDestination(_waypoints[_currentWayPointIndex].position);
            }
        }

        private IEnumerator DissolveEnemy(float animLength)
        {
            SkinnedMeshRenderer[] _parts = GetComponentsInChildren<SkinnedMeshRenderer>(); 
            yield return  new WaitForSeconds(animLength);
            foreach (var part in _parts) {
                part.material = _DissovleMaterial;
            }
            while (_dissolveAmount > 0) {
                _dissolveAmount -= Time.deltaTime * _dissolveSpeed ;  
                foreach (var part in _parts) {
                    part.material.SetFloat(_dissolveAmmountID, _dissolveAmount);
                }
                yield return new WaitForSeconds(Time.deltaTime);
            }
            PoolManager.Instance.ReturnToPool(this.gameObject);
        }

        private IEnumerator DestroyEnemy(float animLength)
        {
            _isHit = true;
            _isDead = true;
            yield return  new WaitForSeconds(0.5f);
            PoolManager.Instance.ReturnToPool(this.gameObject);
        }
        
        private void OnDisable(){
            Manager.GameManager.PauseLevel -= Pause;
            Manager.GameManager.UnpauseLevel -= Unpause;
            Manager.GameManager.StopLevel += Pause;
        }

        public void InitializeHashCodes(int[] hashCodes)
        {
            _idlesHash = hashCodes[0];
            _hitsHash =  hashCodes[1];
            _deathsHash =  hashCodes[2];
            _idealNumberHash =  hashCodes[3];
            _deathHash =  hashCodes[4];
            _hitHash =  hashCodes[5];
            _speedHash = hashCodes[6];
        }
        
        public void InitializeAudioSource() {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.loop = false;
            _audioSource.playOnAwake = false;
            _audioSource.spatialBlend = 1;
            _audioSource.volume = 1;
            _audioSource.outputAudioMixerGroup = _mixerGroup;
        }

        public void ReachedEnd() {
            EnemySurvived?.Invoke();
            PoolManager.Instance.ReturnToPool(this.gameObject);
        }
    }
}