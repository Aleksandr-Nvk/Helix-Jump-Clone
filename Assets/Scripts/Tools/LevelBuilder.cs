using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Settings;

namespace Tools
{
    public class LevelBuilder
    {
        public List<float> PlatformsYPositions = new List<float>();

        public List<IPiece[]> PiecesBehaviours = new List<IPiece[]>();
        
        private List<GameObject> _allPlatformPieces = new List<GameObject>();

        private readonly Vector3 _rotationStep = new Vector3(0f, Consts.PieceAngle, 0f);

        private readonly List<PiecePrefabType> _allPlatformPieceTypes = new List<PiecePrefabType>();
        
        private readonly LevelSettings _settings;

        private readonly PieceCreator _pieceCreator;
        
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
            var position = Vector3.zero;
            var rotation = Vector3.zero;
            
            var pieceToPrefabDictionary = _settings.PieceTypeToPrefab.ToDictionary();

            for (var i = 0; i < _settings.PlatformsCount; i++) // spawning platforms
            {
                var platformPiecesTypes = CreatePiecePrefabTypesList(i);

                DeleteRandomPiecePrefabTypes(platformPiecesTypes);
                
                _allPlatformPieceTypes.AddRange(platformPiecesTypes);
            }
            
            _allPlatformPieces = InstantiatePiecesFromTypes(_allPlatformPieceTypes, pieceToPrefabDictionary, rotation, ref position);

            PiecesBehaviours = GetPiecesBehaviours(_allPlatformPieces); // getting behaviours from the spawned platforms
        }
        
        /// <summary>
        /// Creates list with random piece prefab types
        /// </summary>
        /// <returns> List with random piece prefab types </returns>
        private List<PiecePrefabType> CreatePiecePrefabTypesList(int platformIndex)
        {
            var internalList = new List<PiecePrefabType>();
            
            for (var j = 0; j < Consts.PiecesCount; j++)
            {
                PiecePrefabType prefabType;
                
                prefabType = platformIndex == 0
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
        /// <returns> Spawned pieces </returns>
        private List<GameObject> InstantiatePiecesFromTypes(List<PiecePrefabType> platformPiecesTypes,
            Dictionary<PiecePrefabType, GameObject> pieceToPrefabDictionary, Vector3 rotation, ref Vector3 position)
        {
            var spawnedPieces = new List<GameObject>();
            var positionStep = _settings.SpawnDistance;
            
            PlatformsYPositions = new List<float>();
            PiecesBehaviours = new List<IPiece[]>();

            var itemIndex = 0;
            
            foreach (var piecePrefabType in platformPiecesTypes)
            {
                if (piecePrefabType != PiecePrefabType.EmptyPrefab)
                {
                    var piece = Object.Instantiate(pieceToPrefabDictionary[piecePrefabType], position, Quaternion.Euler(rotation));
                    spawnedPieces.Add(piece);
                }
                else
                {
                    spawnedPieces.Add(null);
                }
                
                itemIndex++;

                if (itemIndex % Consts.PiecesCount == 0)
                {
                    PlatformsYPositions.Add(position.y);
                    position -= positionStep;
                }
                
                rotation += _rotationStep;
            }
            
            return spawnedPieces;
        }

        private List<IPiece[]> GetPiecesBehaviours(List<GameObject> spawnedPieces)
        {
            var internalBehavioursList = new List<IPiece[]>();

            for (var i = 0; i < _settings.PlatformsCount; i++)
            {
                internalBehavioursList.Add(new IPiece[Consts.PiecesCount]); // creating empty pieces behaviours
            }
            
            var internalPiecesList = spawnedPieces;

            foreach (var behaviour in internalBehavioursList)
            {
                for (var i = 0; i < behaviour.Length; i++)
                {
                    if (internalPiecesList[0] != null)
                        behaviour[i] = internalPiecesList[0].GetComponent<IPiece>();
                    else
                        behaviour[i] = null;

                    internalPiecesList.Remove(internalPiecesList[0]);
                }
            }

            return internalBehavioursList;
        }
    }
}