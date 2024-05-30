using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public GameObject _volumeMute;
    public GameObject _volumeUnmute;


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
}
