using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextClick5 : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    private bool isText1 = true;
    public Quest5 quest5;
    public bool EndDialog = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isText1 == true)
            {
                isText1 = false;
            }
            else
            {
                isText1 = true;
                quest5.EndDialog = true;
            }
        }
        if (isText1 == true)
        {
            Text1.SetActive(true);
            Text2.SetActive(false);
        }
        else
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
        }
    }
}
