using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class Entry : MonoBehaviour
    {
#pragma warning disable 0649
        
        [SerializeField] private LevelSettings _settings;
        
#pragma warning restore

        private FromPieceTypeToPrefab _pieces;

        private Dictionary<PieceType, float> _piecesProbabilities;
        
        private void Awake()
        {
            var levelBuilder = new LevelBuilder(_settings, _pieces);
            
            var gameplayManager = new GameplayManager(levelBuilder);
            gameplayManager.Start();
        }
    }
}