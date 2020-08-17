using System.Collections.Generic;
using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class LevelSettings : MonoBehaviour
    {
#pragma warning disable 0649

        [Header("Platforms settings")]
        [SerializeField] private GameObject _friendlyPiece;
        [SerializeField] private GameObject _enemyPiece;
        [SerializeField] private GameObject _flyingPiece;
        
        [SerializeField] private Vector3 _spawnDistance = new Vector3(0f, 1f, 0f);
        
        [SerializeField] private int _count = 50; // platforms count

        [SerializeField] private List<PieceTypeToProbabilityPair> _piecesProbability;
        
#pragma warning restore

        public GameObject FriendlyPiece => _friendlyPiece;
        public GameObject EnemyPiece => _enemyPiece;
        public GameObject FlyingPiece => _flyingPiece;
        public Vector3 SpawnDistance => _spawnDistance;
        public int Count => _count;

        private FromPieceTypeToProbability _piecesProbabilityInternal;
        
        public FromPieceTypeToProbability PiecesProbability
        {
            get
            {
                if (_piecesProbabilityInternal == null)
                    _piecesProbabilityInternal = new FromPieceTypeToProbability();
                
                _piecesProbabilityInternal.Clear();

                foreach (var pair in _piecesProbability)
                {
                    _piecesProbabilityInternal.Add(pair.Key, pair.Value);
                }

                return _piecesProbabilityInternal;
            }
        }
    }
}