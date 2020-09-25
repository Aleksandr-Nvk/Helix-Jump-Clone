using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace UIViews
{
    public class MainMenuView : MonoBehaviour
    {
#pragma warning disable 0649

        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _shopButton;

#pragma warning restore

        private PauseView _pauseView;
        
        public void Init(PauseView pauseView)
        {
            _pauseView = pauseView;
            
            StartCoroutine(CheckScreenTap());
        }

        private IEnumerator CheckScreenTap()
        {
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameObject.SetActive(false);
                    _pauseView.ShowPauseButtonSeparately(true);
                }
                
                yield return null;
            }
        }
    }
}