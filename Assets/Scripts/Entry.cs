using MainGameplay;
using UnityEngine;
using Managers;
using Models.UI;
using Settings;
using Tools;
using UIBehaviours;

// main composition root
public class Entry : MonoBehaviour
{
#pragma warning disable 0649
        
    [SerializeField] private GameplaySettings _settings;
    
    [SerializeField] private BallPositionChecker _ballPositionChecker;
    
    [SerializeField] private GameObject _mainCamera;
    
    [Header("UI")]
    
    [SerializeField] private PauseView _pauseView;

#pragma warning restore
    
    private void Start()
    {
        // creating classes instances which require an existing information or references to each others
        var pieceCreator = new PieceCreator(_settings);
        var levelModelCreator = new LevelModelCreator(pieceCreator, _settings);
        var levelSpawner = new LevelSpawner(_settings);
        var levelBuilder = new LevelBuilder(_settings, levelModelCreator, levelSpawner);
        var cameraMover = new CameraMover(_mainCamera);

        var gameplayManager = new GameplayManager(levelBuilder, levelSpawner, _ballPositionChecker, cameraMover);
        gameplayManager.Start();
        
        // Ui initialization

        var pauseModel = new PauseModel();
        
        _pauseView.OnPause += _pauseView.Show;
        _pauseView.OnPause += pauseModel.Pause;
        _pauseView.OnResume += _pauseView.Hide;
        _pauseView.OnResume += pauseModel.Resume;
        
        _pauseView.Init();
    }
}