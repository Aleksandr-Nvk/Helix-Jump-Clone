using UnityEngine;
using Settings;
using Models;

namespace Tools
{
    // manages pieces generation
    public class PieceCreator
    {
        private readonly GameplaySettings _gameplaySettings;

        public PieceCreator(GameplaySettings settings)
        {
            _gameplaySettings = settings;
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
        /// Chooses random Piece Type depending on randomness probabilities
        /// </summary>
        /// <returns> Random piece type </returns>
        private PieceType GetRandomType()
        {
            var newValue = Random.value;

            return newValue <= _gameplaySettings.EnemyPieceSpawnProbability ? PieceType.Enemy : PieceType.Friendly;
        }
    }
}