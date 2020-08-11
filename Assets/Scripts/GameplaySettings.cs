using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class GameplaySettings : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Platforms settings")]
        [SerializeField] private GameObject _platformPrefab  = null; // platforms to spawn
        [SerializeField] private Vector3    _spawnDistance   = new Vector3(0f, 1f, 0f); // metric interval between platforms
        [SerializeField] private int        _count           = 50;   // platforms count

        [SerializeField] [Range(0f, 1f)] private float _negativeRate = 0.4f; // chance of spawning a negative platform piece
        [SerializeField] [Range(0f, 1f)] private float _emptyRate    = 0.3f; // chance of spawning an empty platform piece
#pragma warning restore

        public GameObject PlatformPrefab => _platformPrefab;
        public Vector3 SpawnDistance => _spawnDistance;
        public int Count => _count;

        public float NegativeRate => _negativeRate;
        public float EmptyRate => _emptyRate;
    }
}