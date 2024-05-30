using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggleInPause : MonoBehaviour
{
    public GameObject _volumeMute;
    public GameObject _volumeUnmute;
    public GameObject _soundEffectMute;
    public GameObject _soundEffectUnmute;
    public bool _soundVolume = true;


    

    public void SoundToggleButton()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            _volumeMute.SetActive(true);
            _volumeUnmute.SetActive(false);
        }

        else
        {
            AudioListener.volume = 0;
            _volumeUnmute.SetActive(true);
            _volumeMute.SetActive(false);
        }
    }

    public void SoundEffectsToggle()
    {
       if (_soundVolume == false)
        {
            _soundVolume = true;
            
            _soundEffectMute.SetActive(true);
            _soundEffectUnmute.SetActive(false);
        }
        else //if (_soundVolume == true)
        {
            _soundVolume = false;
            Debug.Log("ToggleSoundWorks");
            
            _soundEffectMute.SetActive(false);
            _soundEffectUnmute.SetActive(true);
        }
    }
}
