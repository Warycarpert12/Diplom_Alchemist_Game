using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scaledTimer;
    [SerializeField] TextMeshProUGUI _unscaledTimer;

    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _stoneShootingOn;
    [SerializeField] GameObject _stoneShootingOff;
    bool _isPaused = false;

    [SerializeField] StonesCaster _stonesCaster;
    public bool StoneShooting = true;
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
        //_stonesCaster.enabled = false;

        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void StoneShootingToggle()
    {
        if (StoneShooting == false)
        {
            _stonesCaster.enabled = true;
            StoneShooting = true;
            _stoneShootingOn.SetActive(false);
            _stoneShootingOff.SetActive(true);
        }
        else
        {
            _stonesCaster.enabled = false;
            StoneShooting = false;
            _stoneShootingOn.SetActive(true);
            _stoneShootingOff.SetActive(false);
        }
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //_stonesCaster.enabled = true;

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
