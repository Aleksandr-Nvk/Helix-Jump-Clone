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
        // блок создания экземпляров классов, которым нужна уже существующая информация (типа настроек)
        // либо ссылки на друг друга
        var pieceCreator = new PieceCreator(_settings);
        var levelModelCreator = new LevelModelCreator(pieceCreator);
        var levelSpawner = new LevelSpawner(_settings);
        var levelBuilder = new LevelBuilder(_settings, levelModelCreator, levelSpawner);
        var cameraMover = new CameraMover(_settings, _mainCamera);

        // добавление их в контейнер
        _container.Add(_settings);
        _container.Add(_ballPositionChecker);
        _container.Add(pieceCreator);
        _container.Add(_ballBehaviour);
        _container.Add(levelModelCreator);
        _container.Add(levelSpawner);
        _container.Add(levelBuilder);
        _container.Add(cameraMover);
        
        // блок для создания экземпляров управляющих классов, которым нужен весь контейнер
        var gameplayManager = new GameplayManager(_container);
        _container.Add(gameplayManager);
        
        gameplayManager.Start();
        
        // TODO: вся инициализация должна происходить ДО старта
        _ballPositionChecker.Init(_container);
        _ballBehaviour.Init(levelSpawner.GetLevelData());
    }
}