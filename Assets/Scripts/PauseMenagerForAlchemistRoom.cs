using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenagerForAlchemistRoom : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scaledTimer;
    [SerializeField] TextMeshProUGUI _unscaledTimer;

    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _recipBook;

    bool _isPaused = false;

    

    float _scaledTime;
    float _unscaledTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (_isPaused)
            {
                ResumeGame();
                
            }
            else
            {
                PauseGame();
                ;
            }
        }

        UpdateTimers();
    }


    void UpdateTimers()
    {
        _scaledTime += Time.deltaTime;
        _unscaledTime += Time.unscaledDeltaTime;

        _scaledTimer.text = "Scaled Time: " + _scaledTime.ToString("F2");
        _unscaledTimer.text = "Unscaled Time: " + _unscaledTime.ToString("F2");
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        

        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        if (_recipBook.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        

        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        _isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
    }
}
