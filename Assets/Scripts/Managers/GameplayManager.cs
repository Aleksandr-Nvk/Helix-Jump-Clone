using MainGameplay;
using Tools;

namespace Managers
{
    // main gameplay manager
    public class GameplayManager
    {
        private readonly LevelBuilder _levelBuilder;

        private readonly LevelSpawner _levelSpawner;

        private readonly BallPositionChecker _ballPositionChecker;

        private readonly CameraMover _cameraMover;
        
        public GameplayManager(LevelBuilder levelBuilder, LevelSpawner levelSpawner,
            BallPositionChecker ballPositionChecker, CameraMover cameraMover)
        {
            _levelBuilder = levelBuilder;
            _levelSpawner = levelSpawner;
            _ballPositionChecker = ballPositionChecker;
            _cameraMover = cameraMover;
        }

        /// <summary>
        /// Starts the main gameplay
        /// </summary>
        public void Start()
        {
            _levelBuilder.Build(); // building a level
            _ballPositionChecker.Init(_levelSpawner, _cameraMover);
        }
    }
}