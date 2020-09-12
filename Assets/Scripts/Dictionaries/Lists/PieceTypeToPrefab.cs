using UnityEngine;
using System;

namespace Dictionaries.Lists
{
    [Serializable]
    public class PieceTypeToPrefab
    {
        public GameObject FriendlyPrefab;
        public GameObject EnemyPrefab;
        public GameObject FlyingPrefab;
        public GameObject EmptyPrefab;

        public GameObject this[PieceType type]
        {
            get
            {
                switch (type) {
                    case PieceType.Enemy:
                        return EnemyPrefab;
                    case PieceType.Friendly:
                        return FriendlyPrefab;
                    case PieceType.Flying:
                        return FlyingPrefab;
                    case PieceType.Empty:
                        return EmptyPrefab;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
        }
    }
}