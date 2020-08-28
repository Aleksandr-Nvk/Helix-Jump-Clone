using MainGameplay;
using Containers;

namespace Managers
{
    public class GameplayManager
    {
        private readonly LevelBuilder _levelBuilder;

        public GameplayManager(ReferencesContainer referencesContainer)
        {
            _levelBuilder = referencesContainer.Resolve<LevelBuilder>();
        }

        /// <summary>
        /// Starts the main gameplay
        /// </summary>
        public void Start()
        {
            _levelBuilder.Build(); // building a level
        }
    }
}