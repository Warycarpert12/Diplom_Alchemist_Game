using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBoilingScript : MonoBehaviour
{
    public bool isOn;
    [SerializeField] GameObject _boilingPanel;

    public string GetDescription()
    {
        if (isOn) return "Press E to go inside";
        return "Locked";
    }
    public void Interact()
    {
       _boilingPanel.SetActive(true);
    }
}
