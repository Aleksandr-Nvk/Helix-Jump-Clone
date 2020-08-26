using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Containers
{
    public struct LevelData
    {
        public List<IPiece[]> PiecesBehaviours;
        
        public List<float> PlatformsYPositions;

        public List<GameObject> AllPlatformsPieces;
    }
}