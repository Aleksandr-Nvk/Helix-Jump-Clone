using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Interfaces;

namespace UIBehaviours
{
    public class PauseView : MonoBehaviour, IView
    {
    #pragma warning disable 0649

        [SerializeField] private Button _pauseButton;
        
        [Space]
        
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;
        
    #pragma warning restore
        
        public UnityAction OnPause;
        public UnityAction OnResume;

        public void Init()
        {
            _pauseButton.onClick.AddListener(OnPause);
            _resumeButton.onClick.AddListener(OnResume);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}