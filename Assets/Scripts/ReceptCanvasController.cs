using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReceptCanvasController : MonoBehaviour
{
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        
    }


    
    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}