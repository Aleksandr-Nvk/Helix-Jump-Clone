using System;
using UnityEngine;

namespace Models
{
    public class PauseManager
    {
        private bool _isPaused
        {
            get => Mathf.Approximately(Time.timeScale, 0f);
            set {}
        }

        public Action<bool> OnPauseChanged;
        
        public bool IsPaused
        {
            get => _isPaused;
            set {
                if (value != _isPaused)
                {
                    _isPaused = value;
                    OnPauseChanged?.Invoke(_isPaused);
                }
            }
        }
        
        public void Pause()
        {
            if (!IsPaused)
            {
                Time.timeScale = 0f;
                OnPauseChanged?.Invoke(true);
            }
        }

        public void Resume()
        {
            if (IsPaused)
            {
                Time.timeScale = 1f;
                OnPauseChanged?.Invoke(false);
            }
        }
    }
}