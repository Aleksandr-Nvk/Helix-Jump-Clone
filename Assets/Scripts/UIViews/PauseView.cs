using UnityEngine.UI;
using UnityEngine;
using Models;

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

        private StartView _startView;
        
        public void Init(PauseManager pauseManager, GameSession gameSession)
        {
            gameObject.SetActive(pauseManager.IsPaused);

            _pauseButton.onClick.AddListener(pauseManager.Pause);
            
            _resumeButton.onClick.AddListener(pauseManager.Resume);
            
            _restartButton.onClick.AddListener(gameSession.Restart);
            
            _homeButton.onClick.AddListener(gameSession.EndGameSession);

            gameSession.OnSessionProgressChanged += b => ShowPauseButton(gameSession.IsSessionInProgress, pauseManager.IsPaused);
                
            pauseManager.OnPauseChanged += b => ShowPauseButton(gameSession.IsSessionInProgress, pauseManager.IsPaused);

            pauseManager.OnPauseChanged += show => gameObject.SetActive(show);
        }

        /// <summary>
        /// Shows the pause button if conditions are completed
        /// </summary>
        /// <param name="isSessionInProgress"> is session in progress? </param>
        /// <param name="isPaused"> is session paused? </param>
        private void ShowPauseButton(bool isSessionInProgress, bool isPaused)
        {
            _pauseButton.gameObject.SetActive(isSessionInProgress && !isPaused);
        }
    }
}