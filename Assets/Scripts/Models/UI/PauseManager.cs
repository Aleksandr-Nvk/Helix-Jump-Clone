using UnityEngine;
using System;

namespace Models.UI
{
    public class PauseManager
    {
        public bool IsPaused = Mathf.Approximately(Time.timeScale, 0f);

        public Action<bool> OnPauseChanged;
        
        public void Pause()
        {
            OnPauseChanged?.Invoke(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            OnPauseChanged?.Invoke(false);
            Time.timeScale = 1f;
        }
    }
}