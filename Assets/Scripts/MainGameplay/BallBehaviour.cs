using UnityEngine;
using System;

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

        private void Start()
        {
            _startPosition = transform.localPosition;
        }

        private void FixedUpdate()
        {
            if (Math.Abs(_ball.velocity.y) < 0.01f)
                _canJump = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_canJump)
                Jump();
        }

        /// <summary>
        /// Resets ball position
        /// </summary>
        public void ResetPosition()
        {
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
    }
}