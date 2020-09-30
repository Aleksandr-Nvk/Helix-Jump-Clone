using System;
using UnityEngine;

namespace Models
{
    public class PauseManager
    {
        public Action<bool> OnPauseChanged;

        public bool IsPaused
        {
            get => Mathf.Approximately(Time.timeScale, 0f);
            private set => Time.timeScale = value ? 0f : 1f;
        }

        public void Pause()
        {
            if (!IsPaused) {
                IsPaused = true;
                OnPauseChanged?.Invoke(true);
            }
        }

        public void Resume()
        {
            if (IsPaused) {
                IsPaused = false;
                OnPauseChanged?.Invoke(false);
            }
        }
    }
}