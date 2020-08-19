using Dictionaries.Lists;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
#pragma warning disable 0649

    [Header("Ball settings")]
    
    [SerializeField] private GameObject _ball; // ball (player)

    [Header("Platforms settings")]
    
    [SerializeField] private int _platformsCount = 50; // platforms count

    [SerializeField] private Vector3 _spawnDistance = new Vector3(0f, 1f, 0f); // platforms' metric spawn interval
    
    [SerializeField] private GameObject _startPlatform; // ball and the friendly platform under it

    [Header("Pieces settings")]
    
    [SerializeField] private ProbabilityToPieceType _probabilityToPieceType;
    [SerializeField] private PieceTypeToPrefab _pieceTypeToPrefab;
        
#pragma warning restore

    public GameObject Ball => _ball;
    
    public int PlatformsCount => _platformsCount;

    public Vector3 SpawnDistance => _spawnDistance;

    public GameObject StartPlatform => _startPlatform;
    
    public ProbabilityToPieceType ProbabilityToPieceType => _probabilityToPieceType;
    public PieceTypeToPrefab PieceTypeToPrefab => _pieceTypeToPrefab;
}