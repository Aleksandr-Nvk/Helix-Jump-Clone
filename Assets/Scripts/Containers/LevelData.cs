using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Containers
{
    public class LevelData
    {
        public List<Platform<IPiece>> PiecesBehaviours;
        
        public List<float> PlatformsYPositions;

        public List<Platform<GameObject>> AllPlatformsPieces;
    }
}