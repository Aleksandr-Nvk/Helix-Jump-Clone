using UnityEngine;

namespace Main_Gameplay
{
    public class BallMovement : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _ball;

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
            _ball.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }
}
