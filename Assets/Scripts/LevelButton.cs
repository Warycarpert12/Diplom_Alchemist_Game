using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public GameObject pointTP;
     
    public GameObject Clue;








    private void Start()
    {
        pointTP = GameObject.Find("PointTP2");
    }
    public void Update()
    {
        if (pointTP == null)
        {
            pointTP = GameObject.Find("PointTP2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            if(Clue != null)
            {
                Clue.SetActive(true);
                Invoke("DestroyClue", 7);
            }
            
            
            other.gameObject.transform.rotation = pointTP.transform.rotation;
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = pointTP.transform.position;
            Debug.Log("+1");
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }


    void DestroyClue()
    {
        Object.Destroy(Clue);
    }
}


