using System.Collections.Generic;
using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class PieceCreator
    {
        private readonly Dictionary<float, PieceType> _inputDictionary;

        public PieceCreator(LevelSettings levelSettings)
        {
            _inputDictionary = new Dictionary<float, PieceType>(levelSettings.PiecesProbability.Count);
            foreach (var element in levelSettings.PiecesProbability)
            {
                _inputDictionary.Add(element.Key, element.Value);
            }
        }
        
        public PieceModel CreateRandom()
        {
            var piece = new PieceModel(GetRandomType());
            return piece;
        }
        
        private PieceType GetRandomType()
        {
            var probabilities = new List<float>();
            
            PieceType result = default;

            foreach (var key in _inputDictionary)
            {
                probabilities.Add(key.Key);
            }

            probabilities.Sort();
            probabilities.Reverse();

            var intervals = new List<float> { 0f };

            for (var i = 0; i < probabilities.Count; i++)
            {
                intervals.Add(intervals[i] + probabilities[i]);
            }
            
            var random = Random.value;
            
            for (var i = 0; i < probabilities.Count; i++)
            {
                if (random >= intervals[i] && random < intervals[i + 1])
                {
                    result = _inputDictionary[probabilities[i]];
                }
            }
            return result;
        }
    }
}