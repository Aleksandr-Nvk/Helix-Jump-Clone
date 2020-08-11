using UnityEngine;

public class Entry : MonoBehaviour
{
#pragma warning disable 0649

    [SerializeField] private GameplaySettings gameplaySettings;

    [SerializeField] private GameplayManager gameplayManager;

#pragma warning restore

    private void Awake()
    {
        gameplayManager.SetGameplaySettings(gameplaySettings);
    }
}