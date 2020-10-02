using Models;
using UnityEngine;
using UnityEngine.UI;

namespace UIViews
{
    public class GameOverView : MonoBehaviour
    {
    #pragma warning disable 0649

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;

    #pragma warning restore

        public void Init(GameSession gameSession)
        {
            _restartButton.onClick.AddListener(gameSession.Restart);
            
            _homeButton.onClick.AddListener(gameSession.EndGameSession);

            gameSession.OnGameOver += ShowGameOverView;
        }
        
        private void ShowGameOverView(bool isGameOver)
        {
            gameObject.SetActive(isGameOver);
        }
    }
}