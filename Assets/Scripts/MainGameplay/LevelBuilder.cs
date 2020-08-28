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
        
        public LevelBuilder(ReferencesContainer referencesContainer)
        {
            _settings = referencesContainer.Resolve<LevelSettings>();
            _levelModelCreator = referencesContainer.Resolve<LevelModelCreator>();
            _levelSpawner = referencesContainer.Resolve<LevelSpawner>();
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