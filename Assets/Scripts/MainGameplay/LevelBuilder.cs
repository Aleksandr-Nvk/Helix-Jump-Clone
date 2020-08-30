using System.Collections.Generic;
using Containers;
using Settings;
using Tools;

namespace MainGameplay
{
    public class LevelBuilder
    {
        private readonly LevelSettings _settings;

        private readonly LevelModelCreator _levelModelCreator;
        
        private readonly LevelSpawner _levelSpawner;
        
        public LevelBuilder(LevelSettings settings, LevelModelCreator levelModelCreator, LevelSpawner levelSpawner)
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
            var allPlatformsPiecesTypes = new List<PiecePrefabType>();
            
            for (var i = 0; i < _settings.PlatformsCount; i++) // spawning platforms
            {
                var platformPiecesTypes = _levelModelCreator.CreatePiecePrefabTypesList(i);

                _levelModelCreator.DeleteRandomPiecePrefabTypes(platformPiecesTypes);
                
                allPlatformsPiecesTypes.AddRange(platformPiecesTypes);
            }
            
            _levelSpawner.InstantiatePiecesFromTypes(allPlatformsPiecesTypes);
        }
    }
}