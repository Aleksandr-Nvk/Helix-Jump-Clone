using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class LevelBuilder
    {
        private readonly LevelSettings _settings;

        private readonly Vector3 _rotationStep;
        private readonly Vector3 _positionStep;

        private readonly PieceCreator _pieceCreator;
        
        public LevelBuilder(LevelSettings settings)
        {
            _settings = settings;
            
            _positionStep = settings.SpawnDistance;
            _rotationStep = new Vector3(0f, 45, 0f);
            
            _pieceCreator = new PieceCreator(_settings);
        }

        /// <summary>
        /// Builds a new level, according to level settings
        /// </summary>
        public void Build()
        {
            var position = new Vector3(0, -1, 0);
            var rotation = Vector3.zero;

            Object.Instantiate(_settings.StartPlatform);
            Object.Instantiate(_settings.Ball);
            
            var pieceToPrefabDictionary = _settings.PieceTypeToPrefab.ToDictionary();

            for (var i = 0; i < _settings.PlatformsCount; i++) // spawning platforms
            {
                var platformPiecesTypes = CreatePiecePrefabTypesList();

                DeleteRandomPiecePrefabTypes(platformPiecesTypes);

                InstantiatePiecesFromTypes(platformPiecesTypes, pieceToPrefabDictionary, rotation, ref position);
            }
        }

        /// <summary>
        /// Creates list with random piece prefab types
        /// </summary>
        /// <returns> List with random piece prefab types </returns>
        private List<PiecePrefabType> CreatePiecePrefabTypesList()
        {
            var internalList = new List<PiecePrefabType>(8);
            for (var j = 0; j < 8; j++)
            {
                var prefabType = _pieceCreator.CreateRandom().Type;
                internalList.Add(prefabType);
            }

            return internalList;
        }

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

        /// <summary>
        /// Instantiates prefabs depending on each piece prefab type from the list
        /// </summary>
        /// <param name="platformPiecesTypes"> List to instantiate prefabs from </param>
        /// <param name="pieceToPrefabDictionary"> Prefabs settings </param>
        /// <param name="rotation"> Piece rotation </param>
        /// <param name="position"> Piece position </param>
        private void InstantiatePiecesFromTypes(List<PiecePrefabType> platformPiecesTypes,
            Dictionary<PiecePrefabType, GameObject> pieceToPrefabDictionary, Vector3 rotation, ref Vector3 position)
        {
            foreach (var piecePrefabType in platformPiecesTypes)
            {
                if (piecePrefabType != PiecePrefabType.EmptyPrefab)
                {
                    Object.Instantiate(pieceToPrefabDictionary[piecePrefabType], position, Quaternion.Euler(rotation));
                }
                    
                rotation += _rotationStep;
            }
                
            position -= _positionStep;
        }
    }
}