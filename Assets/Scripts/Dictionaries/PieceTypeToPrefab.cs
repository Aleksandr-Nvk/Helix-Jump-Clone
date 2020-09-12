using UnityEngine;
using System;

namespace Dictionaries
{
    // joins piece prefab and its model data
    [Serializable]
    public class PieceTypeToPrefab
    {
        public GameObject FriendlyPrefab;
        public GameObject EnemyPrefab;

        public GameObject this[PieceType type]
        {
            get
            {
                switch (type) {
                    case PieceType.Enemy:
                        return EnemyPrefab;
                    case PieceType.Friendly:
                        return FriendlyPrefab;
                    case PieceType.Empty:
                        return null;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
        }
    }
}