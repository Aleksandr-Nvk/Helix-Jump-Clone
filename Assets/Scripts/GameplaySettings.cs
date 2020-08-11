using UnityEngine;

public class GameplaySettings : MonoBehaviour
{
#pragma warning disable 0649

    [Header("Platforms settings")]
    [SerializeField] public GameObject platformPrefab; // platforms to spawn

    [SerializeField] public int count; // platforms count
    
    [SerializeField] public Vector3 spawnDistance; // metric interval between platforms

    [SerializeField] [Range(0f, 1f)] public float negativeRate; // chance of spawning a negative platform piece
    [SerializeField] [Range(0f, 1f)] public float emptyRate; // chance of spawning an empty platform piece

#pragma warning restore
}