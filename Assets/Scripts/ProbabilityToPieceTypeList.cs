using System;
using System.Collections.Generic;
using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    [Serializable]
    public class ProbabilityToPieceTypeList : BasePairList<float, PieceType>
    {
        [SerializeField] private List<PieceTypeToProbabilityPair> _list;

        protected override IEnumerable<BasePair<float, PieceType>> List => _list;
    }
}