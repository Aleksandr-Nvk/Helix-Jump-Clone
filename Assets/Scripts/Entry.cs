using UnityEngine;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    public class Entry : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private GameplaySettings _settings;
#pragma warning restore

        private void Start()
        {
            var levelBuilder = new LevelBuilder(_settings);
            
            var gameplayManager = new GameplayManager(_settings, levelBuilder);
            gameplayManager.Start();
        }
    }
}