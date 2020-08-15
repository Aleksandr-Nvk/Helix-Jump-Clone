using System.Collections.Generic;
using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class RandomPieceWithKey
    {
        private readonly Dictionary<float, PieceType> _inputDictionary;
        
        public RandomPieceWithKey(Dictionary<float, PieceType> dictionary)
        {
            _inputDictionary = dictionary;
        }

        public PieceType GetRandom()
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