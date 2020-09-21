using UnityEngine.UI;
using UnityEngine;
using Models.UI;
using Managers;

namespace UIViews
{
    public class PauseView : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Button _pauseButton;
        
        [Space]
        
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;
        
    #pragma warning restore

        public void Init(PauseManager pauseManager, GameSession gameSession)
        {
            _pauseButton.onClick.AddListener(pauseManager.Pause);
            
            _resumeButton.onClick.AddListener(pauseManager.Resume);
            
            _restartButton.onClick.AddListener(gameSession.Restart);

            pauseManager.OnPauseChanged += show => gameObject.SetActive(show);
        }
    }
}