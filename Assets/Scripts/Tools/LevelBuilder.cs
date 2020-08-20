using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;
using Settings;

namespace Tools
{
    public class LevelBuilder
    {
        private readonly LevelSettings _settings;
        
        private readonly PieceCreator _pieceCreator;

        private readonly Vector3 _rotationStep = new Vector3(0f, Consts.PieceAngle, 0f);
        
        private readonly List<PiecePrefabType> _allPlatformPieceTypes = new List<PiecePrefabType>();
        
        private List<GameObject> _allPlatformPieces = new List<GameObject>();

        public LevelBuilder(LevelSettings settings, PieceCreator pieceCreator)
        {
            _settings = settings;
            _pieceCreator = pieceCreator;
        }

        /// <summary>
        /// Builds a new level from given level settings
        /// </summary>
        public void Build()
        {
            var position = Vector3.down;
            var rotation = Vector3.zero;

            Object.Instantiate(_settings.StartPlatform);
            Object.Instantiate(_settings.Ball);
            
            var pieceToPrefabDictionary = _settings.PieceTypeToPrefab.ToDictionary();

            for (var i = 0; i < _settings.PlatformsCount; i++) // spawning platforms
            {
                var platformPiecesTypes = CreatePiecePrefabTypesList();

                DeleteRandomPiecePrefabTypes(platformPiecesTypes);
                
                _allPlatformPieceTypes.AddRange(platformPiecesTypes);
            }
            
            _allPlatformPieces = InstantiatePiecesFromTypes(_allPlatformPieceTypes, pieceToPrefabDictionary, rotation, ref position);
        }

        /// <summary>
        /// Creates list with random piece prefab types
        /// </summary>
        /// <returns> List with random piece prefab types </returns>
        private List<PiecePrefabType> CreatePiecePrefabTypesList()
        {
            var internalList = new List<PiecePrefabType>();
            for (var j = 0; j < Consts.PiecesCount; j++)
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
        /// <param name="pieceToPrefabDictionary"> Prefabs and prefab types dictionary </param>
        /// <param name="rotation"> Current piece rotation </param>
        /// <param name="position"> Current piece position </param>
        /// <returns> Spawned pieces list </returns>
        private List<GameObject> InstantiatePiecesFromTypes(List<PiecePrefabType> platformPiecesTypes,
            Dictionary<PiecePrefabType, GameObject> pieceToPrefabDictionary, Vector3 rotation, ref Vector3 position)
        {
            var spawnedPieces = new List<GameObject>();
            var positionStep = _settings.SpawnDistance;

            var itemIndex = 0;
            foreach (var piecePrefabType in platformPiecesTypes)
            {
                itemIndex++;
                
                if (piecePrefabType != PiecePrefabType.EmptyPrefab)
                {
                    var piece = Object.Instantiate(pieceToPrefabDictionary[piecePrefabType], position, Quaternion.Euler(rotation));
                    spawnedPieces.Add(piece);
                }

                if (itemIndex % Consts.PiecesCount == 0)
                    position -= positionStep;

                rotation += _rotationStep;
            }
            
            return spawnedPieces;
        }
    }
}