using UnityEngine;

namespace Models
{
    public class SettingsManager
    {
        private readonly AudioSource _audioSource;
        
        public bool IsVibrationOn = true;

        public SettingsManager(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }
        
        public void SetMute()
        {
            _audioSource.mute = !_audioSource.mute;
            Debug.Log($"Volume {_audioSource.mute}");
        }
        
        public void SetVibration()
        {
            IsVibrationOn = !IsVibrationOn;
            
            if (IsVibrationOn)
                Handheld.Vibrate();
        }
    }
}