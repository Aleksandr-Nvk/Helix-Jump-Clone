using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class LevelBuilder
    {
        private readonly GameplaySettings _settings;

        public LevelBuilder(GameplaySettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Builds a new level, according to gameplay settings
        /// </summary>
        /// <param name="settings"> Settings to follow </param>
        public void Build()
        {
            var spawnPosition = Vector3.zero;
            for (var i = 0; i < _settings.Count; i++)
            {
                Object.Instantiate(_settings.PlatformPrefab, spawnPosition, Quaternion.identity);
                spawnPosition -= _settings.SpawnDistance;
            }
        }
    }
}