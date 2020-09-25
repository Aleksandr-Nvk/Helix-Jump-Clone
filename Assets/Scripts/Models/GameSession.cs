using MainGameplay;
using Tools;

namespace Models
{
    // main gameplay manager
    public class GameSession
    {
        private readonly LevelBuilder _levelBuilder;

        private readonly LevelSpawner _levelSpawner;

        private readonly PauseManager _pauseManager;
        
        private readonly BallPositionChecker _ballPositionChecker;
        
        private readonly BallBehaviour _ballBehaviour;

        private readonly BallMovement _ballMovement;
        
        private readonly CameraMover _cameraMover;
        
        public GameSession(LevelBuilder levelBuilder, LevelSpawner levelSpawner, PauseManager pauseManager,
            BallPositionChecker ballPositionChecker, BallBehaviour ballBehaviour, BallMovement ballMovement, CameraMover cameraMover)
        {
            _levelBuilder = levelBuilder;
            _levelSpawner = levelSpawner;
            _pauseManager = pauseManager;
            _ballPositionChecker = ballPositionChecker;
            _ballBehaviour = ballBehaviour;
            _ballMovement = ballMovement;
            _cameraMover = cameraMover;
        }

        /// <summary>
        /// Starts the main gameplay
        /// </summary>
        public void Start()
        {
            _levelBuilder.Build();
            _ballPositionChecker.Init(_levelSpawner, _cameraMover);
        }

        /// <summary>
        /// Restarts the game with a new level
        /// </summary>
        public void Restart()
        {
            _pauseManager.Resume();
            
            _levelBuilder.Rebuild();
            _cameraMover.ResetPosition();
            _ballBehaviour.ResetPosition();
            _ballMovement.ResetRotation();
            _ballPositionChecker.Reset();
        }
    }
}