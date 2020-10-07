using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Models;

namespace UIViews
{
    public class StartView : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _shopButton;

    #pragma warning restore
        
        public UnityAction OnShopButtonPressed;
        public UnityAction OnSettingsButtonPressed;
        
        private GameSession _gameSession;

        public void Init(GameSession gameSession)
        {
            _gameSession = gameSession;
            
            _shopButton.onClick.AddListener(OnShopButtonPressed);
            _settingsButton.onClick.AddListener(OnSettingsButtonPressed);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _gameSession.Start();
        }
        
        /// <summary>
        /// Shows the view
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides the view
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}