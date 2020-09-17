using UnityEngine;

namespace MainGameplay
{
    // manages ball movement
    public class BallMovement : MonoBehaviour
    {
    #pragma warning disable 0649
    
        [SerializeField] private float _rotationSpeed = 20f;
        
    #pragma warning restore

        private float _currentMousePosition;
        private float _oldMousePosition;

        private bool isIdle;
        
        private void Update()
        {
            isIdle = Input.GetMouseButtonDown(0); // don't move if just touched, but not dragged

            if (Input.GetMouseButton(0))
            {
                _currentMousePosition = Input.mousePosition.x;

                if (!isIdle)
                {
                    var speed = (_oldMousePosition - _currentMousePosition) * _rotationSpeed;
                    transform.eulerAngles += Time.deltaTime * speed * Vector3.up;
                }

                _oldMousePosition = _currentMousePosition; // resetting written values
            }
        }

        /// <summary>
        /// Resets ball rotation
        /// </summary>
        public void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }
    }
}