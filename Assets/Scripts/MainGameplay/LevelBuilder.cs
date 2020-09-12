﻿using System.Collections.Generic;
using Containers;
using Settings;
using Tools;

namespace MainGameplay
{
    // manages level building process
    public class LevelBuilder
    {
        private readonly GameplaySettings _settings;

        private readonly LevelModelCreator _levelModelCreator;

        private readonly LevelSpawner _levelSpawner;

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
    }
}