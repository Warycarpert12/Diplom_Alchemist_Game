using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public void StartGame()
    {
        SceneManager.LoadScene("VillageScene");
    }

    public void TitlesOpen()
    {
        SceneManager.LoadScene("GameEndScene");
        AudioListener.volume = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
