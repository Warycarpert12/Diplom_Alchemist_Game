using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButtonInForest : MonoBehaviour
{
    public GameObject pointTP;

    private void Start()
    {
        pointTP = GameObject.Find("PointTP4");
    }
    public void Update()
    {
        if (pointTP == null)
        {
            pointTP = GameObject.Find("PointTP4");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.rotation = pointTP.transform.rotation;
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = pointTP.transform.position;
            Debug.Log("+1");
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
}
