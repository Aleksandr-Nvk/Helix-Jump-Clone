using UnityEngine;
using Models;

namespace UIViews
{
    public class MainView : MonoBehaviour
    {
#pragma warning disable 0649
        
        [SerializeField] private StartView _startView;

        [SerializeField] private ShopView _shopView;

        [SerializeField] private SettingsView _settingsView;
        
#pragma warning restore

        public void Init(GameSession gameSession, SettingsManager settingsManager, ShopManager shopManager)
        {
            _startView.OnShopButtonPressed += () =>
            {
                _startView.Hide();
                _shopView.Show();
            };
            _startView.OnSettingsButtonPressed += () =>
            {
                _startView.Hide();
                _settingsView.Show();
            };
            _shopView.OnCloseButtonPressed += () =>
            {
                _shopView.Hide();
                _startView.Show();
            };
            _settingsView.OnCloseButtonPressed += () =>
            {
                _settingsView.Hide();
                _startView.Show();
            };

            gameSession.OnSessionProgressChanged += started =>
            {
                if (started)
                    Show();
                else
                    Hide();
            };
            
            // monobehaviours' initializations
            
            _startView.Init(gameSession);
            _shopView.Init(shopManager);
            _settingsView.Init(settingsManager);
        }

        /// <summary>
        /// Shows the view
        /// </summary>
        private void Show()
        {
            gameObject.SetActive(true);
            _startView.Show();
        }

        /// <summary>
        /// Hides the view
        /// </summary>
        private void Hide()
        {
            _shopView.Hide();
            _startView.Hide();
            gameObject.SetActive(false);
        }
    }
}