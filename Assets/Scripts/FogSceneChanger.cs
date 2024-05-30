using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FogSceneChanger : MonoBehaviour
{
    private void Start()
    {
      
        SceneManager.LoadScene("ForestScene",LoadSceneMode.Additive);
        SceneManager.LoadScene("AlchemistRoom", LoadSceneMode.Additive);
        Debug.Log("+1");
    }


    public static void SwitchScene(string sceneName)
    {
        Scene targetScen = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(targetScen);
    }
}
