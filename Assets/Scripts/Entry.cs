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

    [SerializeField] private BallBehaviour _ballBehaviour;
    
    [SerializeField] private GameObject _mainCamera;

#pragma warning restore
    
    private readonly ReferencesContainer _container = new ReferencesContainer();
        
    private void Start()
    {
        // creating classes instances which require an existing information or references to each others
        var pieceCreator = new PieceCreator(_settings);
        var levelModelCreator = new LevelModelCreator(pieceCreator, _settings);
        var levelSpawner = new LevelSpawner(_settings);
        var levelBuilder = new LevelBuilder(_settings, levelModelCreator, levelSpawner);
        var cameraMover = new CameraMover(_settings, _mainCamera);

        // adding references to the container
        _container.Add(_settings);
        _container.Add(_ballPositionChecker);
        _container.Add(pieceCreator);
        _container.Add(_ballBehaviour);
        _container.Add(levelModelCreator);
        _container.Add(levelSpawner);
        _container.Add(levelBuilder);
        _container.Add(cameraMover);
        
        // creating instances of classes that require all the existing references
        var gameplayManager = new GameplayManager(_container);
        _container.Add(gameplayManager);
        
        gameplayManager.Start();
    }
}