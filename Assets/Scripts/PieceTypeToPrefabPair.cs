using System;
using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    [Serializable]
    public class PieceTypeToPrefabPair : BasePair<PiecePrefabType, GameObject>
    {
        public PieceTypeToPrefabPair(PiecePrefabType key, GameObject value) : base(key, value)
        { }
    }
}