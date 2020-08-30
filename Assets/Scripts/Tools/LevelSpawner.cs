using System.Collections.Generic;
using UnityEngine;
using Containers;
using Interfaces;
using Settings;

namespace Tools
{
    public class LevelSpawner
    {
        private readonly LevelSettings _settings;

        private readonly List<float> _platformsYPositions = new List<float>();

        private readonly Vector3 _rotationStep = new Vector3(0f, Consts.PieceAngle, 0f);

        private List<IPiece[]> _piecesBehaviours = new List<IPiece[]>();
        
        private readonly List<GameObject> _allPlatformsPieces = new List<GameObject>();

        private Vector3 _ballRotation;
        
        public LevelSpawner(LevelSettings settings)
        {
            _settings = settings;
        }
        
        /// <summary>
        /// Instantiates prefabs depending on each piece prefab type from the list
        /// </summary>
        /// <param name="platformPiecesTypes"> List to instantiate prefabs from </param>
        public void InstantiatePiecesFromTypes(List<PiecePrefabType> platformPiecesTypes)
        {
            var position = Vector3.zero;
            var rotation = Vector3.zero;

            var positionStep = _settings.SpawnDistance;

            var _ballIsPlaced = false;

            var itemIndex = 0;
            
            foreach (var piecePrefabType in platformPiecesTypes)
            {
                if (itemIndex >= 0 && itemIndex <= 7 && !_ballIsPlaced) // ball position validator
                {
                    if (piecePrefabType != PiecePrefabType.EmptyPrefab)
                    {
                        _ballRotation = rotation;
                        _ballIsPlaced = true;
                    }
                }
                if (piecePrefabType != PiecePrefabType.EmptyPrefab)
                {
                    var pieceTypeToPrefab = _settings.PieceTypeToPrefab.ToDictionary();
                    var piece = Object.Instantiate(pieceTypeToPrefab[piecePrefabType], position, Quaternion.Euler(rotation));
                    _allPlatformsPieces.Add(piece);
                }
                else
                {
                    _allPlatformsPieces.Add(null);
                }
                
                itemIndex++;

                if (itemIndex % Consts.PiecesCount == 0)
                {
                    _platformsYPositions.Add(position.y);
                    position -= positionStep;
                }
                
                rotation += _rotationStep;
            }

            GetPiecesBehaviours(_allPlatformsPieces);
        }

        /// <summary>
        /// Gets data from the built level
        /// </summary>
        /// <returns> Level data </returns>
        public LevelData GetLevelData()
        {
            var levelData = new LevelData
            {
                PiecesBehaviours = _piecesBehaviours,
                PlatformsYPositions = _platformsYPositions,
                AllPlatformsPieces = _allPlatformsPieces,
                BallRotation = _ballRotation
            };

            return levelData;
        }
        
        /// <summary>
        /// Gets behaviour script type from each piece
        /// </summary>
        /// <param name="spawnedPieces"> Pieces to get behaviours from </param>
        private void GetPiecesBehaviours(List<GameObject> spawnedPieces)
        {
            _piecesBehaviours = new List<IPiece[]>();

            for (var i = 0; i < _settings.PlatformsCount; i++)
            {
                _piecesBehaviours.Add(new IPiece[Consts.PiecesCount]); // creating empty pieces behaviours
            }
            
            var internalPiecesList = spawnedPieces;

            foreach (var behaviour in _piecesBehaviours)
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
        }
    }
}