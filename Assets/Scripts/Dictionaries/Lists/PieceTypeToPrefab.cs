using System.Collections.Generic;
using Dictionaries.Pairs;
using UnityEngine;
using System;

namespace Dictionaries.Lists
{
    [Serializable]
    public class PieceTypeToPrefab : BasePairList<PiecePrefabType, GameObject>
    {
    #pragma warning disable 0649
        
        [SerializeField] private List<PieceTypeToPrefabPair> _list;
        
    #pragma warning restore
        
        protected override IEnumerable<BasePair<PiecePrefabType, GameObject>> List => _list;
    }
}