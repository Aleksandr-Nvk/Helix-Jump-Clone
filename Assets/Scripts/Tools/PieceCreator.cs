using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Containers;
using Settings;
using Models;

namespace Tools
{
    public class PieceCreator
    {
        private readonly ReferencesContainer _referencesContainer;
        private readonly Dictionary<float, PieceType> _inputDictionary;

        public PieceCreator(LevelSettings settings)
        {
            _inputDictionary = settings.ProbabilityToPieceType.ToDictionary();
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
        /// Creates new Friendly Piece Model
        /// </summary>
        /// <returns> Friendly Piece Model </returns>
        public PieceModel CreateFriendly()
        {
            return new PieceModel(PieceType.Friendly);
        }

        /// <summary>
        /// Creates new Enemy Piece Model
        /// </summary>
        /// <returns> Enemy Piece Model </returns>
        public PieceModel CreateEnemy()
        {
            return new PieceModel(PieceType.Enemy);
        }

        /// <summary>
        /// Creates new Flying Piece Model
        /// </summary>
        /// <returns> Flying Piece Model </returns>
        public PieceModel CreateFlying()
        {
            return new PieceModel(PieceType.Flying);
        }

        /// <summary>
        /// Chooses random Piece Type depending on randomness probabilities
        /// </summary>
        /// <returns> Random piece type </returns>
        private PieceType GetRandomType()
        {
            var probabilities = _inputDictionary.Select(pair => pair.Key).ToList();

            probabilities.Sort();
            probabilities.Reverse();

            var intervals = new List<float> { 0f }; // intervals with the start of interval coordinates (zero)

            for (var i = 0; i < probabilities.Count; i++)
            {
                var intervalCheckPoint = intervals[i] + probabilities[i];
                intervals.Add(intervalCheckPoint); // intervals with probabilities checkpoints
            }

            var random = Random.value;

            var result = PieceType.Empty;

            for (var i = 0; i < probabilities.Count; i++)
            {
                if (random >= intervals[i] && random < intervals[i + 1]) // iterating and checking the similarities
                    result = _inputDictionary[probabilities[i]];
            }

            return result;
        }
    }
}