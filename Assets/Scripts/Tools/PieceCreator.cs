using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Settings;
using Models;

namespace Tools
{
    public class PieceCreator
    {
        private readonly Dictionary<float, PieceType> _inputDictionary = new Dictionary<float, PieceType>();

        public PieceCreator(LevelSettings levelSettings)
        {
            var newDictionary = levelSettings.ProbabilityToPieceType.ToDictionary();
            
            foreach (var pair in newDictionary)
            {
                _inputDictionary.Add(pair.Key, pair.Value);
            }
        }
        
        /// <summary>
        /// Creates new Piece Model from random Piece Type
        /// </summary>
        /// <returns> Random Piece Model </returns>
        public PieceModel CreateRandom()
        {
            return new PieceModel(GetRandomType());
        }
        
        /// <summary>
        /// Chooses random Piece Type depending on randomness probabilities
        /// </summary>
        /// <returns> Random piece type </returns>
        private PieceType GetRandomType()
        {
            PieceType result = default;

            var probabilities = _inputDictionary.Select(pair => pair.Key).ToList();

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