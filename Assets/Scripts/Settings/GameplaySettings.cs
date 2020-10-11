using Dictionaries;
using UnityEngine;

namespace Settings
{
    // collects main gameplay settings
    public class GameplaySettings : MonoBehaviour
    {
    #pragma warning disable 0649

        [Header("Platforms settings")]
    
        [SerializeField] private int _platformsCount = 50;

        [SerializeField] private Vector3 _spawnDistance = new Vector3(0f, 1f, 0f);

        [Header("Pieces settings")]
        
        [SerializeField] [Range(0f, 1f)] private float _enemyPieceSpawnProbability = 0.5f;
        
        [SerializeField] private PieceTypeToPrefab _pieceTypeToPrefab;
        
        [Header("Ball settings")]
        
        [SerializeField] private GameObject _spot;

#pragma warning restore
        
        public int PlatformsCount => _platformsCount;

        public Vector3 SpawnDistance => _spawnDistance;
        
        public float EnemyPieceSpawnProbability => _enemyPieceSpawnProbability;
        
        public PieceTypeToPrefab PieceTypeToPrefab => _pieceTypeToPrefab;

        public GameObject Spot => _spot;
    }
}