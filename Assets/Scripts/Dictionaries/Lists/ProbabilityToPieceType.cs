using System.Collections.Generic;
using Dictionaries.Pairs;
using UnityEngine;
using System;

namespace Dictionaries.Lists
{
    [Serializable]
    public class ProbabilityToPieceType : BasePairList<float, PieceType>
    {
    #pragma warning disable 0649
        
        [SerializeField] private List<ProbabilityToPieceTypePair> _list;
        
    #pragma warning restore
        
        protected override IEnumerable<BasePair<float, PieceType>> List => _list;
    }
}