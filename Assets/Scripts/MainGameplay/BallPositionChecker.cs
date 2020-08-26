using System.Collections.Generic;
using UnityEngine;
using Containers;
using Interfaces;

namespace MainGameplay
{
    public class BallPositionChecker : MonoBehaviour
    {
        private List<float> _platformsYPositions = new List<float>();
        
        private List<IPiece[]> _piecesBehaviours = new List<IPiece[]>();
        
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
            }
        }
        
        /// <summary>
        /// Sets built level data
        /// </summary>
        /// <param name="levelData"> Built level data </param>
        public void SetLevelData(LevelData levelData)
        {
            _platformsYPositions = levelData.PlatformsYPositions;
            _piecesBehaviours = levelData.PiecesBehaviours;
        }
    }
}