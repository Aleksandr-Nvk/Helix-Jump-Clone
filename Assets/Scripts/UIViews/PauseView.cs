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

            pauseManager.OnPauseChanged += show =>
            {
                gameObject.SetActive(show);
                ShowPauseButtonSeparately(!show);
            };
            
            _homeButton.onClick.AddListener(() =>
            {
                pauseManager.Home(); // sets timescale and calls an event
                gameSession.Restart(); // restarts the game
                mainMenuView.gameObject.SetActive(true); // activates the main menu
                ShowPauseButtonSeparately(false); // hides the pause button
                
                mainMenuView.Init(this); // restarts ScreenTapChecker
            });
        }

        /// <summary>
        /// Shows or hides the pause button separately from the whole pause menu
        /// </summary>
        /// <param name="show"></param>
        public void ShowPauseButtonSeparately(bool show)
        {
            _pauseButton.gameObject.SetActive(show);
        }
    }
}