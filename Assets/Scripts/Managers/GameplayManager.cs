using MainGameplay;
using Containers;

namespace Managers
{
    public class GameplayManager
    {
        private readonly LevelBuilder _levelBuilder;

        private readonly BallPositionChecker _ballPositionChecker;

        private readonly ReferencesContainer _referencesContainer;

        public GameplayManager(ReferencesContainer referencesContainer)
        {
            _referencesContainer = referencesContainer;
            _levelBuilder = referencesContainer.Resolve<LevelBuilder>();
            _ballPositionChecker = referencesContainer.Resolve<BallPositionChecker>();
        }

        /// <summary>
        /// Starts the main gameplay
        /// </summary>
        public void Start()
        {
            _levelBuilder.Build(); // building a level
            _ballPositionChecker.Init(_referencesContainer);
        }
    }
}