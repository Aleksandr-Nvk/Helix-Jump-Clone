using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class Entry : MonoBehaviour
    {
#pragma warning disable 0649
        
        [SerializeField] private LevelSettings _settings;
        
#pragma warning restore
        
        private FromPieceTypeToPrefab _pieces;

        private FromPieceTypeToProbability _piecesProbabilities;
        
        private void Start()
        {
            _pieces = new FromPieceTypeToPrefab();
            
            var levelBuilder = new LevelBuilder(_settings, _pieces); // ???
            
            var gameplayManager = new GameplayManager(levelBuilder);
            gameplayManager.Start();
        }
    }
}