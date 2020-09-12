using UnityEngine.UI;
using UnityEngine;
using Models.UI;

namespace UIBehaviours
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

        private readonly PauseViewModel _pauseViewModel = new PauseViewModel();
        
        private void Awake()
        {
            _pauseButton.onClick.AddListener(() => _pauseViewModel.Show(gameObject));
            _pauseButton.onClick.AddListener(_pauseViewModel.Pause);
            
            _resumeButton.onClick.AddListener(() => _pauseViewModel.Hide(gameObject));
            _resumeButton.onClick.AddListener(_pauseViewModel.Resume);
            
            _pauseViewModel.Hide(gameObject);
        }
    }
}