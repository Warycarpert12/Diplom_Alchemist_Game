using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractiveButton : MonoBehaviour
{
    public GameObject targetCanvas;
    private bool isPlayerInRange = false;
    public GameObject _cookingClue;

    bool _isPaused = false;
    [SerializeField] TextMeshProUGUI _scaledTimer;
    [SerializeField] TextMeshProUGUI _unscaledTimer;
    float _scaledTime;
    float _unscaledTime;


    void Start()
    {
        if (targetCanvas != null)
        {
            targetCanvas.SetActive(false); // Начально Canvas выключен
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (_isPaused)
            {
                
            }
            else
            {
                PauseGame();
                ;
            }
            UpdateTimers();

            if (targetCanvas != null)
            {
                _cookingClue.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                targetCanvas.SetActive(true); // Включаем Canvas при нажатии клавиши E
               
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cookingClue.SetActive(true);
            isPlayerInRange = true;
            // Вы можете добавить визуальные подсказки, например, отобразить текст "Нажмите E для взаимодействия"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cookingClue.SetActive(false);
            isPlayerInRange = false;
            // Скрыть визуальные подсказки
        }
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
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
        _isPaused = false;
    }
}

