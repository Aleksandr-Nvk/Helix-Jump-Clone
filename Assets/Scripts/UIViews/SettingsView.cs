using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Models;

namespace UIViews
{
    public class SettingsView : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField] private Button _closeButton;

        [SerializeField] private Button _volume;
        [SerializeField] private Button _vibration;
        [SerializeField] private Button _info;
        
#pragma warning restore

        public UnityAction OnCloseButtonPressed;
        
        public void Init(SettingsManager settingsManager)
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
            
            _volume.onClick.AddListener(settingsManager.SetMute);
            _vibration.onClick.AddListener(settingsManager.SetVibration);
            _info.onClick.AddListener(() => Application.OpenURL("https://www.google.com"));
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