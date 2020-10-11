using MainGameplay;
using UnityEngine;
using Settings;
using UIViews;
using Models;
using Tools;

// main composition root
public class Entry : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Unity objects")]
    
    [SerializeField] private GameObject _mainCamera;
    
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Material _ballMaterial;
    
    [Header("Behaviours")]

    [SerializeField] private GameplaySettings _settings;
    
    [SerializeField] private BallPositionChecker _ballPositionChecker;
    
    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private BallBehaviour _ballBehaviour;
    
    [Header("UI")]
    
    [SerializeField] private MainView _mainView;
    
    [SerializeField] private PauseView _pauseView;
    
    [SerializeField] private GameOverView _gameOverView;
    
#pragma warning restore
    
    private void Start()
    {
        // creating classes instances which require an existing information or references to each others
        var pieceCreator = new PieceCreator(_settings);
        var levelModelCreator = new LevelModelCreator(pieceCreator, _settings);
        var levelSpawner = new LevelSpawner(_settings);
        var levelBuilder = new LevelBuilder(_settings, levelModelCreator, levelSpawner);
        var cameraMover = new CameraMover(_mainCamera);
        var pauseManager = new PauseManager();
        var settingsManager = new SettingsManager(_audioSource);
        var shopManager = new ShopManager(_ballMaterial);

        var gameSession = new GameSession(levelBuilder, levelSpawner, pauseManager, _ballPositionChecker, _ballBehaviour,
            _ballMovement, cameraMover);

        _ballBehaviour.Init(gameSession, settingsManager, _settings, _audioSource);
        
        // Ui initialization
        
        _mainView.Init(gameSession, settingsManager, shopManager);
        _pauseView.Init(pauseManager, gameSession);
        _gameOverView.Init(gameSession);
    }
}