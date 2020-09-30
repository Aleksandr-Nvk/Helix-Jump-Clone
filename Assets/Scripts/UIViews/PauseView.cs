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

        private MainMenuView _mainMenuView;
        
        public void Init(PauseManager pauseManager, GameSession gameSession, MainMenuView mainMenuView)
        {
            gameObject.SetActive(pauseManager.IsPaused);

            _pauseButton.onClick.AddListener(pauseManager.Pause);
            
            _resumeButton.onClick.AddListener(pauseManager.Resume);
            
            _restartButton.onClick.AddListener(gameSession.Restart);
            
            gameSession.OnSessionProgressChanged +=
                b => ShowPauseButton(gameSession.IsSessionInProgress, pauseManager.IsPaused);
                
            pauseManager.OnPauseChanged +=
                b => ShowPauseButton(gameSession.IsSessionInProgress, pauseManager.IsPaused);

            pauseManager.OnPauseChanged += show => gameObject.SetActive(show);
            
            _homeButton.onClick.AddListener(() =>
            {
                gameSession.Restart(); // restarts the game
                gameSession.IsSessionInProgress = false;
                mainMenuView.gameObject.SetActive(true); // activates the main menu
                mainMenuView.Init(pauseManager, gameSession); // restarts ScreenTapChecker
            });
        }

        private void ShowPauseButton(bool isSessionInProgress, bool isPaused)
        {
            _pauseButton.gameObject.SetActive(isSessionInProgress && !isPaused);
        }
    }
}