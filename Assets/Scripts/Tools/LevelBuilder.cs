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
            _rotationStep = new Vector3(0f, 45f, 0f);
            
            _pieceCreator = new PieceCreator(_settings);
        }

        /// <summary>
        /// Builds a new level, according to level settings
        /// </summary>
        public void Build()
        {
            var position = Vector3.zero;
            for (var i = 0; i < _settings.PlatformsCount; i++) // spawning platforms
            {
                var rotation = Vector3.zero;
                for (var j = 0; j < 8; j++) // spawning pieces
                {
                    var prefabType = _pieceCreator.CreateRandom().Type;
                    var pieceToPrefabDictionary = _settings.PieceTypeToPrefab.ToDictionary();
                    Object.Instantiate(pieceToPrefabDictionary[prefabType], position, Quaternion.Euler(rotation));
                    
                    rotation += _rotationStep;
                }

                position -= _positionStep;
            }
        }
    }
}