using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Containers
{
    public class LevelData
    {
        public List<IPiece[]> PiecesBehaviours;
        
        public List<float> PlatformsYPositions;

        public List<GameObject> AllPlatformsPieces;

        public Vector3 BallRotation;
    }
}