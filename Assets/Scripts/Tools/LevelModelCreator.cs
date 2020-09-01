using Containers;
using Settings;
using UnityEngine;

namespace Tools
{
    public class LevelModelCreator
    {
        private readonly PieceCreator _pieceCreator;
        private readonly LevelSettings _levelSettings;

        public LevelModelCreator(PieceCreator pieceCreator, LevelSettings levelSettings)
        {
            _pieceCreator = pieceCreator;
            _levelSettings = levelSettings;
        }

        /// <summary>
        /// Creates list with random piece prefab types
        /// </summary>
        /// <param name="platformIndex"> Current platform index </param>
        /// <returns> List with random piece prefab types </returns>
        public Platform<PiecePrefabType> CreatePlatformModel(int platformIndex)
        {
            var internalPlatform = new Platform<PiecePrefabType>();
            
            for (var i = 0; i < Consts.PiecesCount; i++)
            {
                var prefabType = platformIndex == 0
                    ? _pieceCreator.CreateFriendly().Type
                    : _pieceCreator.CreateRandom().Type;

                internalPlatform.Pieces[i] = prefabType;
            }

            DeleteRandomPiecePrefabTypes(internalPlatform, platformIndex);
            
            return internalPlatform;
        }

        /// <summary>
        /// Replaces 1-2 random piece prefab types from the list with empty type
        /// </summary>
        /// <param name="platformPiecesTypes"> List to modify </param>
        /// <param name="platformIndex"> Current platform index </param>
        private void DeleteRandomPiecePrefabTypes(Platform<PiecePrefabType> platformPiecesTypes, int platformIndex)
        {
            var emptyPiecesCount = Random.Range(1, 3);

            if (platformIndex != _levelSettings.PlatformsCount - 1)
            {
                var lowerBound = platformIndex == 0
                    ? 1
                    : 0;
            
                for (var k = 0; k < emptyPiecesCount; k++)
                {
                    var randomItem = Random.Range(lowerBound, platformPiecesTypes.Pieces.Length);
                    platformPiecesTypes.Pieces[randomItem] = PiecePrefabType.EmptyPrefab;
                }
            }
        }
    }
}