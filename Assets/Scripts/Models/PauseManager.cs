using System;
using UnityEngine;

namespace Models
{
    public class PauseManager
    {
        public bool IsPaused = Mathf.Approximately(Time.timeScale, 0f);

        public Action<bool> OnPauseChanged;
        
        public void Pause()
        {
            Time.timeScale = 0f;
            OnPauseChanged?.Invoke(true);
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            OnPauseChanged?.Invoke(false);
        }

        public void Home()
        {
            if (IsPaused)
            {
                Time.timeScale = 1f;
                OnPauseChanged?.Invoke(false);
            }
            else
            {
                OnPauseChanged?.Invoke(true);
            }
        }
    }
}