using UnityEngine;

public class LevelBuilder
{
    /// <summary>
    /// Builds a new level, according to gameplay settings
    /// </summary>
    /// <param name="settings"> Settings to follow </param>
    public void Build(GameplaySettings settings)
    {
        var spawnPosition = Vector3.zero;
        for (var i = 0; i < settings.count; i++)
        {
            Object.Instantiate(settings.platformPrefab, spawnPosition, Quaternion.identity);
            spawnPosition -= settings.spawnDistance;
        }
    }
}