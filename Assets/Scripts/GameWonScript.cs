﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonScript : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
