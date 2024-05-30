using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

   
    public void LoadRoomLevel()

    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(3);

    }
    public void LoadSceneLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 3 || currentSceneIndex == 4)
        {
            SceneManager.LoadScene(1);
        }
        else if (currentSceneIndex == 1)
        {
            SceneManager.LoadScene(4);

        }
    }

}

    

