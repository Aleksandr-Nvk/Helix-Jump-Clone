using System;
using System.Collections.Generic;
using Containers;
using Interfaces;
using Settings;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MainGameplay
{
    // manages level building process
    public class LevelBuilder
    {
        private readonly GameplaySettings _settings;

        private readonly LevelModelCreator _levelModelCreator;

        private readonly LevelSpawner _levelSpawner;

        private readonly LevelData _levelData;

        public LevelBuilder(GameplaySettings settings, LevelModelCreator levelModelCreator, LevelSpawner levelSpawner)
        {
            _settings = settings;
            _levelModelCreator = levelModelCreator;
            _levelSpawner = levelSpawner;
        }

        /// <summary>
        /// Builds a new level from given level settings
        /// </summary>
        public void Build()
        {
            var allPlatformsPiecesTypes = new List<Platform<PieceType>>();
            for (var i = 0; i < _settings.PlatformsCount; i++) // spawning platforms
            {
                var platformPiecesTypes = _levelModelCreator.CreatePlatformModel(i);
                allPlatformsPiecesTypes.Add(platformPiecesTypes);
            }

            _levelSpawner.InstantiatePiecesFromTypes(allPlatformsPiecesTypes);
        }

        /// <summary>
        /// Deletes the current level and builds a new one
        /// </summary>
        public void Rebuild()
        {
            Clear();
            Build();
        }

        private void Clear()
        {
            var levelData = _levelSpawner.GetLevelData();
            levelData.PiecesBehaviours.Clear();
            
            foreach (var platform in levelData.AllPlatformsPieces)
            {
                foreach (var piece in platform.Pieces)
                {        
                    Object.Destroy(piece);
                }
            }
            
            levelData.AllPlatformsPieces.Clear();
            levelData.PlatformsYPositions.Clear();
        }
    }
}