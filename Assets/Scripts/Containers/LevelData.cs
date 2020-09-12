using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Containers
{
    // represents newly built level data
    public class LevelData
    {
        public List<Platform<IPiece>> PiecesBehaviours;
        
        public List<float> PlatformsYPositions;

        public List<Platform<GameObject>> AllPlatformsPieces;
    }
}