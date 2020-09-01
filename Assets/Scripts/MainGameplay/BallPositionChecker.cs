using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Containers;
using Interfaces;
using Tools;

namespace MainGameplay
{
    public class BallPositionChecker : MonoBehaviour
    {
        private List<float> _platformsYPositions = new List<float>();
        
        private List<Platform<IPiece>> _piecesBehaviours = new List<Platform<IPiece>>();
        
        private CameraMover _cameraMover;

        /// <summary>
        /// MonoBehaviour constructor
        /// </summary>
        /// <param name="referencesContainer"> References container </param>
        public void Init(ReferencesContainer referencesContainer)
        {
            _platformsYPositions = referencesContainer.Resolve<LevelSpawner>().GetLevelData().PlatformsYPositions;
            _piecesBehaviours = referencesContainer.Resolve<LevelSpawner>().GetLevelData().PiecesBehaviours;
            _cameraMover = referencesContainer.Resolve<CameraMover>();
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