using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private GameplaySettings _gameplaySettings;
    
    private void Start()
    {
        var levelBuilder = new LevelBuilder();
        levelBuilder.Build(_gameplaySettings); // building a level
    }
    
    /// <summary>
    /// Sets gameplay settings reference
    /// </summary>
    /// <param name="gameplaySettings"> Gameplay settings </param>
    public void SetGameplaySettings(GameplaySettings gameplaySettings)
    {
        _gameplaySettings = gameplaySettings;
    }
}