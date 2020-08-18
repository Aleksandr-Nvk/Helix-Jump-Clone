using UnityEngine;
using Tools;

public class Entry : MonoBehaviour
{
#pragma warning disable 0649
        
    [SerializeField] private LevelSettings _settings;
        
#pragma warning restore

    private FromPieceTypeToProbability _piecesProbabilities;
        
    private void Start()
    {
        var levelBuilder = new LevelBuilder(_settings);
            
        var gameplayManager = new GameplayManager(levelBuilder);
        gameplayManager.Start();
    }
}