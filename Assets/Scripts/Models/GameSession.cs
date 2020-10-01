using MainGameplay;
using System;
using Tools;

namespace Models
{
    // main gameplay manager
    public class GameSession
    {
        private readonly LevelBuilder _levelBuilder;

        private readonly PauseManager _pauseManager;
        
        private readonly BallPositionChecker _ballPositionChecker;
        
        private readonly BallBehaviour _ballBehaviour;

        private readonly BallMovement _ballMovement;
        
        private readonly CameraMover _cameraMover;

        private bool _isSessionInProgress = false;

        public Action<bool> OnSessionProgressChanged;
        
        public bool IsSessionInProgress
        {
            get => _isSessionInProgress;
            private set {
                if (value != _isSessionInProgress)
                {
                    _isSessionInProgress = value;
                    OnSessionProgressChanged?.Invoke(!_isSessionInProgress);
                }
            }
        }
        
        public GameSession(LevelBuilder levelBuilder, LevelSpawner levelSpawner, PauseManager pauseManager,
            BallPositionChecker ballPositionChecker, BallBehaviour ballBehaviour, BallMovement ballMovement, CameraMover cameraMover)
        {
            _levelBuilder = levelBuilder;
            _pauseManager = pauseManager;
            _ballPositionChecker = ballPositionChecker;
            _ballBehaviour = ballBehaviour;
            _ballMovement = ballMovement;
            _cameraMover = cameraMover;
            
            _levelBuilder.Build();
            _ballPositionChecker.Init(levelSpawner, _cameraMover);
        }

        /// <summary>
        /// Starts the game session
        /// </summary>
        public void Start()
        {
            IsSessionInProgress = true;
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
        
        /// <summary>
        /// End the current session
        /// </summary>
        public void EndGameSession()
        {
            Restart();
            IsSessionInProgress = false;
        }
    }
}