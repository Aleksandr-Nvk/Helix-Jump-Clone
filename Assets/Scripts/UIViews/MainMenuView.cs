using UnityEngine.UI;
using UnityEngine;
using Models;

namespace UIViews
{
    public class MainMenuView : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _shopButton;

#pragma warning restore
        
        private GameSession _gameSession;
        
        public void Init(GameSession gameSession)
        {
            _gameSession = gameSession;
            
            _gameSession.OnSessionProgressChanged += ShowMainMenuView;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _gameSession.Start();
        }

        private void ShowMainMenuView(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}