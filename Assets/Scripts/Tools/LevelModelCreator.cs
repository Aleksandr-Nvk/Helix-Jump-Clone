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
        public List<PiecePrefabType> CreatePiecePrefabTypesList(int platformIndex, bool deleteRandom = true)
        {
            var internalList = new List<PiecePrefabType>();
            
            for (var j = 0; j < Consts.PiecesCount; j++)
            {
                var prefabType = platformIndex == 0
                    ? _pieceCreator.CreateFriendly().Type
                    : _pieceCreator.CreateRandom().Type;

                internalList.Add(prefabType);
            }

            if (deleteRandom)
                DeleteRandomPiecePrefabTypes(internalList);
            
            return internalList;
        }
        
        // TODO: инкапсулировала логику удаления кусочков в класс и выделила ее как настройку метода Create,
        // т.к. решила, что пользователю данного класса приходится делать лишнее действие (вовремя использовать 2ой метод,
        // использовать методы в правильном порядке), что может привести к ошибке
        /// <summary>
        /// Replaces 1-2 random piece prefab types from the list with empty type
        /// </summary>
        /// <param name="platformPiecesTypes"> List to modify </param>
        private void DeleteRandomPiecePrefabTypes(List<PiecePrefabType> platformPiecesTypes)
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