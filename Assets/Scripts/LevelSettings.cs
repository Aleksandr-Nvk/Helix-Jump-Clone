using System.Collections.Generic;
using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class LevelSettings : MonoBehaviour
    {
#pragma warning disable 0649

        [Header("Platforms settings")]
        
        [SerializeField] private Vector3 _spawnDistance = new Vector3(0f, 1f, 0f);
        
        [SerializeField] private int _count = 50; // platforms count

        [SerializeField] private List<PieceTypeToProbabilityPair> _piecesProbability;
        
        [SerializeField] private ProbabilityToPieceTypeList _probabilityToPieceType; // вот это должно появиться в инспекторе
        
        [SerializeField] private List<PieceTypeToPrefabPair> _piecesPrefab;
        
#pragma warning restore

        public Vector3 SpawnDistance => _spawnDistance;
        public int Count => _count;

        private FromPieceTypeToProbability _piecesProbabilityInternal;
        private FromPieceTypeToPrefab _piecesPrefabInternal;
        
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
        public FromPieceTypeToPrefab PiecesPrefab
        {
            get
            {
                if (_piecesPrefabInternal == null)
                    _piecesPrefabInternal = new FromPieceTypeToPrefab();
                
                _piecesPrefabInternal.Clear();

                foreach (var pair in _piecesPrefab)
                {
                    _piecesPrefabInternal.Add(pair.Key, pair.Value);
                }

                return _piecesPrefabInternal;
            }
        }
    }
}