using UnityEngine;

namespace MainGameplay
{
    public class BallBehaviour : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _ball;
        [SerializeField] private Rigidbody _ballParent;
        
    #pragma warning restore

        private void Start()
        {
            // ball start position validation
            var parent = _ballParent.gameObject;
            var ray = new Ray(parent.transform.position, Vector3.down);
            Physics.Raycast(ray, out var data);
            
            // TODO: Check ray length
        }

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