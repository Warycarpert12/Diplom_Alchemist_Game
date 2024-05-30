using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextClick3 : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    private bool isText1 = true;
    public Quest3 quest3;
    public bool EndDialog = false;

    // Update is called once per frame
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
                quest3.EndDialog = true;
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
