using UnityEngine;

namespace Models.UI
{
    public class PauseModel
    {
        public void Pause()
        {
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            Time.timeScale = 1f;
        }
    }
}