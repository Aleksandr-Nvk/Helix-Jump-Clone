using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class LevelBuilder
    {
        private readonly LevelSettings _settings;

        private readonly Vector3 _rotationStep;
        private readonly Vector3 _positionStep;

        public LevelBuilder(LevelSettings settings, FromPieceTypeToPrefab instancesDictionary)
        {
            _settings = settings;
            _positionStep = settings.SpawnDistance;
            
            _rotationStep = new Vector3(0f, 45f, 0f);
        }

        /// <summary>
        /// Builds a new level, according to level settings
        /// </summary>
        public void Build()
        {
            var position = Vector3.zero;
            for (var i = 0; i < _settings.Count; i++)
            {
                var rotation = Vector3.zero;
                for (var j = 0; j < 8; j++)
                {
                    var instance = Object.Instantiate(_settings.FriendlyPiece, position, Quaternion.Euler(rotation));
                    
                    rotation += _rotationStep;
                }

                position -= _positionStep;
            }
        }
    }
}