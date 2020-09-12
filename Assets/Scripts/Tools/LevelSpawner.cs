using System.Collections.Generic;
using UnityEngine;
using Containers;
using Interfaces;
using Settings;

namespace Tools
{
    // manages editor level spawner
    public class LevelSpawner
    {
        private readonly GameplaySettings _settings;

        private readonly List<float> _platformsYPositions = new List<float>();

        private readonly Vector3 _rotationStep = new Vector3(0f, Consts.PieceAngle, 0f);

        private List<Platform<IPiece>> _piecesBehaviours = new List<Platform<IPiece>>();

        private readonly List<Platform<GameObject>> _allPlatformsPieces = new List<Platform<GameObject>>();

        public LevelSpawner(GameplaySettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Instantiates prefabs depending on each piece prefab type from the list
        /// </summary>
        /// <param name="platformPiecesTypes"> List to instantiate prefabs from </param>
        public void InstantiatePiecesFromTypes(List<Platform<PieceType>> platformPiecesTypes)
        {
            var position = Vector3.zero;
            var rotation = Vector3.zero;

            var positionStep = _settings.SpawnDistance;

            for (var i = 0; i < _settings.PlatformsCount; i++)
            {
                _allPlatformsPieces.Add(new Platform<GameObject>());
            }

            for (var i = 0; i < platformPiecesTypes.Count; i++)
            {
                for (var j = 0; j < platformPiecesTypes[i].Pieces.Length; j++)
                {
                    if (platformPiecesTypes[i].Pieces[j] != PieceType.Empty)
                    {
                        var pieceToSpawn = _settings.PieceTypeToPrefab[platformPiecesTypes[i].Pieces[j]];
                        var pieceInstance = Object.Instantiate(pieceToSpawn, position, Quaternion.Euler(rotation));

                        _allPlatformsPieces[i].Pieces[j] = pieceInstance;
                    }
                    else
                    {
                        _allPlatformsPieces[i].Pieces[j] = null;
                    }

                    rotation += _rotationStep;
                }

                _platformsYPositions.Add(position.y);

                position -= positionStep;
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
            };

            return levelData;
        }

        /// <summary>
        /// Gets behaviour script type from each piece
        /// </summary>
        /// <param name="spawnedPieces"> Pieces to get behaviours from </param>
        private void GetPiecesBehaviours(List<Platform<GameObject>> spawnedPieces)
        {
            _piecesBehaviours = new List<Platform<IPiece>>();

            for (var i = 0; i < spawnedPieces.Count; i++)
            {
                var platformBehaviours = new Platform<IPiece>();

                for (var j = 0; j < platformBehaviours.Pieces.Length; j++)
                {
                    if (spawnedPieces[i].Pieces[j] != null)
                        platformBehaviours.Pieces[j] = spawnedPieces[i].Pieces[j].GetComponent<IPiece>();
                    else
                        platformBehaviours.Pieces[j] = null;
                }
                _piecesBehaviours.Add(platformBehaviours);
            }
        }
    }
}