using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Tools
{
    public class PieceCreator
    {
        private readonly Dictionary<float, PieceType> _inputDictionary;

        public PieceCreator(LevelSettings levelSettings)
        {
            var newDictionary = levelSettings.ProbabilityToPieceType.ToDictionary();
            _inputDictionary = new Dictionary<float, PieceType>(newDictionary.Count);
            foreach (var element in newDictionary)
            {
                _inputDictionary.Add(element.Key, element.Value);
            }
        }
        
        /// <summary>
        /// Creates new Piece Model from random Piece Type
        /// </summary>
        /// <returns> Random Piece Model </returns>
        public PieceModel CreateRandom()
        {
            var piece = new PieceModel(GetRandomType());
            return piece;
        }
        
        /// <summary>
        /// Chooses random Piece Type depending on randomness probabilities
        /// </summary>
        /// <returns></returns>
        private PieceType GetRandomType()
        {
            var probabilities = new List<float>();
            
            PieceType result = default;

            foreach (var key in _inputDictionary)
            {
                probabilities.Add(key.Key); // all probabilities list
            }

            probabilities.Sort();
            probabilities.Reverse();

            var intervals = new List<float> { 0f };

            for (var i = 0; i < probabilities.Count; i++)
            {
                intervals.Add(intervals[i] + probabilities[i]); // intervals with probabilities checkpoints
            }
            
            var random = Random.value;
            
            for (var i = 0; i < probabilities.Count; i++)
            {
                if (random >= intervals[i] && random < intervals[i + 1]) // iterating and checking the similarities
                {
                    result = _inputDictionary[probabilities[i]];
                }
            }
            return result;
        }
    }
}