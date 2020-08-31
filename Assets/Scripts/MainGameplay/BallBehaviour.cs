using Containers;
using UnityEngine;

namespace MainGameplay
{
    public class BallBehaviour : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _ball;

        [SerializeField] private GameObject _ballParent;

    #pragma warning restore

        private void OnCollisionEnter(Collision collision)
        {
            Jump();
        }

        /// <summary>
        /// Makes the ball jump
        /// </summary>
        private void Jump()
        {
            _ball.velocity = Vector3.zero;
            _ball.AddForce(Vector3.up * 1f, ForceMode.Impulse);
        }
    }
}