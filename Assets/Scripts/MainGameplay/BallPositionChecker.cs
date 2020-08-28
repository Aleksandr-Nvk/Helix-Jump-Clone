using System.Collections.Generic;
using UnityEngine;
using Containers;
using Interfaces;
using Tools;

namespace MainGameplay
{
    public class BallPositionChecker : MonoBehaviour
    {
        private List<float> _platformsYPositions = new List<float>();
        
        private List<IPiece[]> _piecesBehaviours = new List<IPiece[]>();
        
        private CameraMover _cameraMover;

        /// <summary>
        /// MonoBehaviour constructor
        /// </summary>
        /// <param name="referencesContainer"> ReferencesContainer </param>
        public void Init(ReferencesContainer referencesContainer)
        {
            _platformsYPositions = referencesContainer.Resolve<LevelSpawner>().GetLevelData().PlatformsYPositions;
            _piecesBehaviours = referencesContainer.Resolve<LevelSpawner>().GetLevelData().PiecesBehaviours;
            _cameraMover = referencesContainer.Resolve<CameraMover>();
        }
        
        private void Update()
        {
            if (transform.position.y < _platformsYPositions[0])
            {
                foreach (var piece in _piecesBehaviours[0])
                {
                    piece?.Delete(1f);
                }
                
                _platformsYPositions.Remove(_platformsYPositions[0]);
                _piecesBehaviours.Remove(_piecesBehaviours[0]);
                
                _cameraMover.Move(_platformsYPositions[0]);
            }
        }
    }
}