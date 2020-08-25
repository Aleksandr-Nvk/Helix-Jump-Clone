using MainGameplay;
using UnityEngine;
using Managers;
using Settings;
using Tools;

public class Entry : MonoBehaviour
{
#pragma warning disable 0649
        
    [SerializeField] private LevelSettings _settings;
    
    [SerializeField] private BallBehaviour _ballBehaviour;
    
#pragma warning restore

    private FromPieceTypeToProbability _piecesProbabilities;
        
    private void Start()
    {
        var pieceCreator = new PieceCreator(_settings);
        
        var levelBuilder = new LevelBuilder(_settings, pieceCreator);
        
        var gameplayManager = new GameplayManager(levelBuilder);
        gameplayManager.Start();
        
        _ballBehaviour.SetLevelData(levelBuilder.PlatformsYPositions, levelBuilder.PiecesBehaviours);

    }
}