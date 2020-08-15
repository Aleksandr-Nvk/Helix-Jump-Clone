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
        
#pragma warning restore

        public GameObject FriendlyPiece => _friendlyPiece;
        public GameObject EnemyPiece => _enemyPiece;
        public GameObject FlyingPiece => _flyingPiece;
        public Vector3 SpawnDistance => _spawnDistance;
        public int Count => _count;
    }
}