using MainGameplay;
using UnityEngine;
using Containers;
using Managers;
using Settings;
using Tools;

public class Entry : MonoBehaviour
{
#pragma warning disable 0649
        
    [SerializeField] private LevelSettings _settings;
    
    [SerializeField] private BallPositionChecker _ballPositionChecker;

    [SerializeField] private GameObject _mainCamera;

#pragma warning restore
    
    private readonly ReferencesContainer _container = new ReferencesContainer();
        
    private void Start()
    {
        _container.Add(_settings);
        _container.Add(_ballPositionChecker);
        
        var pieceCreator = new PieceCreator(_container);
        _container.Add(pieceCreator);

        var levelModelCreator = new LevelModelCreator(_container);
        _container.Add(levelModelCreator);
        
        var levelSpawner = new LevelSpawner(_container);
        _container.Add(levelSpawner);

        var levelBuilder = new LevelBuilder(_container);
        _container.Add(levelBuilder);
        
        var gameplayManager = new GameplayManager(_container);
        _container.Add(gameplayManager);
        gameplayManager.Start();
        
        var cameraMover = new CameraMover(_settings, _mainCamera);
        _container.Add(cameraMover);
        
        _ballPositionChecker.Init(_container);
    }
}