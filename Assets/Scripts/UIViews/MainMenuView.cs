using System.Collections;
using Models;
using UnityEngine.UI;
using UnityEngine;

namespace UIViews
{
    public class MainMenuView : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _shopButton;

#pragma warning restore

        private PauseManager _pauseManager;

        private GameSession _gameSession;
        
        public void Init(PauseManager pauseManager, GameSession gameSession)
        {
            _pauseManager = pauseManager;
            _gameSession = gameSession;
            
            StartCoroutine(CheckScreenTap());
        }

        private IEnumerator CheckScreenTap()
        {
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _gameSession.IsSessionInProgress = true;
                    gameObject.SetActive(false);
                }
                
                yield return null;
            }
        }
    }
}