using DG.Tweening;
using UnityEngine;
using Settings;

namespace MainGameplay
{
    public class CameraMover
    {
        private readonly GameObject _camera;
        
        public CameraMover(LevelSettings settings, GameObject mainCamera)
        {
            _camera = mainCamera;
        }

        /// <summary>
        /// Moves camera towards the next platform
        /// </summary>
        /// <param name="nextPlatformYPosition"></param>
        public void Move(float nextPlatformYPosition)
        {
            _camera.transform.DOMoveY(nextPlatformYPosition, 1f);
        }
    }
}
