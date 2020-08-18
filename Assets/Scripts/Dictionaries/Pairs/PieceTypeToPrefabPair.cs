using UnityEngine;
using System;

namespace Dictionaries.Pairs
{
    [Serializable]
    public class PieceTypeToPrefabPair : BasePair<PiecePrefabType, GameObject>
    {
        public PieceTypeToPrefabPair(PiecePrefabType key, GameObject value) : base(key, value)
        { }
    }
}