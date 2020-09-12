using UnityEngine;
using DG.Tweening;

namespace MainGameplay
{
    // manages camera movement
    public class CameraMover
    {
        private readonly GameObject _camera;
        
        public CameraMover(GameObject mainCamera)
        {
            _camera = mainCamera;
        }

        /// <summary>
        /// Moves camera towards the next platform
        /// </summary>
        /// <param name="nextPlatformYPosition"> Platform to move to </param>
        public void Move(float nextPlatformYPosition)
        {
            _camera.transform.DOMoveY(nextPlatformYPosition, 1f);
        }
    }
}
