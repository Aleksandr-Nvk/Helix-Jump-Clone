using UnityEngine;
using System;
using DG.Tweening;
using Models;
using Settings;

namespace MainGameplay
{
    // manages main ball behaviour
    public class BallBehaviour : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _ball;
        
    #pragma warning restore

        private bool _canJump = true;

        private Vector3 _startPosition;

        private GameSession _gameSession;

        private SettingsManager _settingsManager;

        private GameObject _spot;

        private AudioSource _mainAudioSource;

        public void Init(GameSession gameSession, SettingsManager settingsManager, GameplaySettings gameplaySettings,
            AudioSource mainAudioSource)
        {
            _gameSession = gameSession;
            _settingsManager = settingsManager;
            _spot = gameplaySettings.Spot;
            _mainAudioSource = mainAudioSource;
            
            _startPosition = transform.localPosition;
        }

        private void FixedUpdate()
        {
            if (Math.Abs(_ball.velocity.y) < 0.01f && !_ball.isKinematic)
                _canJump = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.gameObject.CompareTag("EnemyPiece"))
            {
                if (_canJump)
                { 
                    SpawnSpot(collision); 
                    Jump();
                    _mainAudioSource.Play();
                }
            }
            else
            {
                Destroy();
                _gameSession.EndGameSessionCompletely();
            }
            
        }

        /// <summary>
        /// Resets ball position
        /// </summary>
        public void Reset()
        {
            _ball.gameObject.transform.DOScale(Vector3.one, 1f);
            _ball.isKinematic = false;
            transform.localPosition = _startPosition;
        }
        
        /// <summary>
        /// Makes the ball jump
        /// </summary>
        private void Jump()
        {
            _ball.velocity = Vector3.zero;
            _ball.AddForce(Vector3.up * 4f, ForceMode.Impulse);

            _canJump = false;
        }

        /// <summary>
        /// Runs the animation of ball destruction
        /// </summary>
        private void Destroy()
        {
            if (_settingsManager.IsVibrationOn)
            {
                Handheld.Vibrate();
            }

            _ball.gameObject.transform.DOScale(Vector3.zero, 1f);
            _ball.isKinematic = true;
        }

        private void SpawnSpot(Collision collision)
        {
            var spawnPosition = new Vector3(0f, 0.005f) + collision.GetContact(0).point;
            var newSpot = Instantiate(_spot, spawnPosition, _spot.transform.rotation);
            UnityEngine.Object.Destroy(newSpot, 1f);
        }
    }
}