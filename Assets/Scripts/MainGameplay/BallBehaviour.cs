using UnityEngine;
using System;
using DG.Tweening;
using Models;

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

        public void Init(GameSession gameSession)
        {
            _gameSession = gameSession;
            
            _startPosition = transform.localPosition;
        }

        private void FixedUpdate()
        {
            if (Math.Abs(_ball.velocity.y) < 0.01f)
                _canJump = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.gameObject.CompareTag("EnemyPiece"))
            {
                if (_canJump)
                    Jump();
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
        public void Destroy()
        {
            _ball.gameObject.transform.DOScale(Vector3.zero, 1f);
        }
    }
}