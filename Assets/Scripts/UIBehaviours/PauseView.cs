using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Interfaces;
using MainGameplay;
using Models.UI;

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

        public UnityAction OnRestart;

        public void Init(PauseModel pauseModel, LevelBuilder levelBuilder, CameraMover cameraMover,
            BallBehaviour ballBehaviour, BallMovement ballMovement, BallPositionChecker ballPositionChecker)
        {
            OnPause += Show;
            OnPause += pauseModel.Pause;
            _pauseButton.onClick.AddListener(OnPause);

            OnResume += Hide;
            OnResume += pauseModel.Resume;
            _resumeButton.onClick.AddListener(OnResume);

            OnRestart += Hide;
            OnRestart += pauseModel.Resume;
            OnRestart += levelBuilder.Rebuild;
            OnRestart += cameraMover.ResetPosition;
            OnRestart += ballBehaviour.ResetPosition;
            OnRestart += ballMovement.ResetRotation;
            OnRestart += ballPositionChecker.Reset;
            _restartButton.onClick.AddListener(OnRestart);
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