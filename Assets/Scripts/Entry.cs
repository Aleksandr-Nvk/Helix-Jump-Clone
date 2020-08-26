using MainGameplay;
using UnityEngine;
using Managers;
using Settings;
using Tools;

public class Entry : MonoBehaviour
{
#pragma warning disable 0649
        
    [SerializeField] private LevelSettings _settings;
    
    [SerializeField] private BallPositionChecker _ballPositionChecker;
    
#pragma warning restore

    private FromPieceTypeToProbability _piecesProbabilities;
        
    private void Start()
    {
        var pieceCreator = new PieceCreator(_settings);
        
        var levelModelCreator = new LevelModelCreator(pieceCreator);
        var levelSpawner = new LevelSpawner(_settings);
        
        var levelBuilder = new LevelBuilder(_settings, levelModelCreator, levelSpawner);
        
        var gameplayManager = new GameplayManager(levelBuilder);
        gameplayManager.Start();
        
        _ballPositionChecker.SetLevelData(levelSpawner.GetLevelData());
    }
}