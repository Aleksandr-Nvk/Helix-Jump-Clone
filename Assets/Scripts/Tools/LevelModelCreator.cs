using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class LevelModelCreator
    {
        private readonly PieceCreator _pieceCreator;

        public LevelModelCreator(PieceCreator pieceCreator)
        {
            _pieceCreator = pieceCreator;
        }

        /// <summary>
        /// Creates list with random piece prefab types
        /// </summary>
        /// <param name="platformIndex"> Current platform index </param>
        /// <returns> List with random piece prefab types </returns>
        public List<PiecePrefabType> CreatePiecePrefabTypesList(int platformIndex)
        {
            var internalList = new List<PiecePrefabType>();
            
            for (var j = 0; j < Consts.PiecesCount; j++)
            {
                var prefabType = platformIndex == 0
                    ? _pieceCreator.CreateFriendly().Type
                    : _pieceCreator.CreateRandom().Type;

                internalList.Add(prefabType);
            }

            return internalList;
        }

        /// <summary>
        /// Replaces 1-2 random piece prefab types from the list with empty type
        /// </summary>
        /// <param name="platformPiecesTypes"> List to modify </param>
        public void DeleteRandomPiecePrefabTypes(List<PiecePrefabType> platformPiecesTypes)
        {
            var emptyPiecesCount = Random.Range(1, 3);

            for (var k = 0; k < emptyPiecesCount; k++)
            {
                var randomItem = Random.Range(0, platformPiecesTypes.Count);
                platformPiecesTypes[randomItem] = PiecePrefabType.EmptyPrefab;
            }
        }
    }
}