using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerehodForest : MonoBehaviour
{
    public GameObject pointTP;
    public GameObject Clue;
   

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.rotation = pointTP.transform.rotation;
            if (Clue != null)
            {
                Clue.SetActive(true);
                Invoke("DeleteClue", 7);
            }
            
            other.gameObject.transform.position = pointTP.transform.position;
            //Debug.Log("+1");
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    void DeleteClue()
    {
        Object.Destroy(Clue);
    }
   
}
