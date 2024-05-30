using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomButton : MonoBehaviour, IInteractable
{

    public bool isOn;


    public string GetDescription()
   {
        if (isOn) return "Press E to go inside";
        return "Locked";
   }
    public void Interact()
    {
        LevelController controller = new LevelController();
        controller.LoadRoomLevel();
    }

}
