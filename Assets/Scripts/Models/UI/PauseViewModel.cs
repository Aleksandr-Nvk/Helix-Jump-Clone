using UnityEngine;
using Interfaces;

namespace Models.UI
{
    public class PauseViewModel : IView
    {
        public void Pause()
        {
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            Time.timeScale = 1f;
        }
        
        public void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}