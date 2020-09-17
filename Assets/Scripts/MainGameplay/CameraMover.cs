using UnityEngine;
using DG.Tweening;

namespace MainGameplay
{
    // manages camera movement
    public class CameraMover
    {
        private readonly GameObject _camera;

        private readonly Vector3 _startPosition;

        private Tween _cameraMoving;
        
        public CameraMover(GameObject mainCamera)
        {
            _camera = mainCamera;
            
            _startPosition = _camera.transform.localPosition;
        }

        /// <summary>
        /// Moves camera towards the next platform
        /// </summary>
        /// <param name="nextPlatformYPosition"> Platform to move to </param>
        public void Move(float nextPlatformYPosition)
        {
            _cameraMoving = _camera.transform.DOMoveY(nextPlatformYPosition, 1f);
        }

        /// <summary>
        /// Resets camera position
        /// </summary>
        public void ResetPosition()
        {
            _cameraMoving.Kill(); // stop camera movement animation
            _camera.transform.localPosition = _startPosition;
        }
    }
}
