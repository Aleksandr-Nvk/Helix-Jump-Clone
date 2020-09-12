using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Containers;
using Interfaces;
using Tools;

namespace MainGameplay
{
    // manages ball position triggers
    public class BallPositionChecker : MonoBehaviour
    {
        private List<float> _platformsYPositions = new List<float>();
        
        private List<Platform<IPiece>> _piecesBehaviours = new List<Platform<IPiece>>();
        
        private CameraMover _cameraMover;

        /// <summary>
        /// MonoBehaviour constructor
        /// </summary>
        /// <param name="levelSpawner"> Level spawner </param>
        /// <param name="cameraMover"> Camera mover </param>
        public void Init(LevelSpawner levelSpawner, CameraMover cameraMover)
        {
            _platformsYPositions = levelSpawner.GetLevelData().PlatformsYPositions;
            _piecesBehaviours = levelSpawner.GetLevelData().PiecesBehaviours;
            _cameraMover = cameraMover;
        }
        
        private void Update()
        {
            if (transform.position.y < _platformsYPositions.First())
            {
                foreach (var piece in _piecesBehaviours.First().Pieces)
                {
                    piece?.Delete(3f);
                }
                
                _platformsYPositions.Remove(_platformsYPositions.First());
                _piecesBehaviours.Remove(_piecesBehaviours.First());
                
                _cameraMover.Move(_platformsYPositions.First());

                if ( _platformsYPositions.Count == 1) // check if only one platform left
                    Debug.Log("Won");
            }
        }
    }
}