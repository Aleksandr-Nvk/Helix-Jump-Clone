using UnityEngine;

namespace MainGameplay
{
    public class BallMovement : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Rigidbody _ball;
        [SerializeField] private Rigidbody _ballParent;

        [SerializeField] private float _rotationSpeed = 20f;
        

#pragma warning restore

        private float _currentMousePosition;
        private float _oldMousePosition;

        private bool isIdle;

        private void Update()
        {
            isIdle = Input.GetMouseButtonDown(0);

            if (Input.GetMouseButton(0))
            {
                _currentMousePosition = Input.mousePosition.x;

                if (!isIdle)
                {
                    var speed = (_oldMousePosition - _currentMousePosition) * _rotationSpeed;
                    _ballParent.gameObject.transform.eulerAngles += Time.deltaTime * speed * Vector3.up;
                }

                _oldMousePosition = _currentMousePosition;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Jump();
            print(collision.collider.gameObject.name);
        }

        /// <summary>
        /// Makes the ball jump
        /// </summary>
        private void Jump()
        {
            _ball.velocity = Vector3.zero;
            _ball.AddForce(Vector3.up * 4f, ForceMode.Impulse);
        }
    }
}