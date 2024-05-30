using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picked_Quest : MonoBehaviour
{
    public bool Quest1;
    public GameObject Text1;
    public bool end_Quest1;
    public bool TextDone;

    public bool Quest2;
    public GameObject Text2;
    public bool end_Quest2;
    public bool TextDone2;


    public bool Quest3;
    public GameObject Text3;
    public bool end_Quest3;
    public bool TextDone3;


    public bool Quest4;
    public GameObject Text4;
    public bool end_Quest4;
    public bool TextDone4;


    public bool Quest5;
    public GameObject Text5;
    public bool end_Quest5;
    public bool TextDone5;

    public static Picked_Quest instance;


    void Start()
    {
       
    }

    void Update()
    {

        if (end_Quest1 == false)
        { 
        if (Quest1 == true)
        {
            Text1.SetActive(true);
            TextDone = true;
        }
        else
        {
            Text1.SetActive(false);
        }
        }
        else
        {
            Text1.SetActive(false);
        }

        ///////////////////////////////////
        if (end_Quest1 == true && end_Quest2 == false)
        {
            if (Quest2 == true)
            {
                Text2.SetActive(true);
                TextDone2 = true;
            }
            else
            {
                Text2.SetActive(false);
            }
            
        }
        else
        {
            Text2.SetActive(false);
        }
        /////////////////////////////////////
        ///
        if (end_Quest1 == true && end_Quest2 == true && end_Quest3 ==false)
        {
            if (Quest3 == true)
            {
                Text3.SetActive(true);
                TextDone3 = true;
            }
            else
            {
                Text3.SetActive(false);
            }

        }
        else
        {
            Text3.SetActive(false);
        }
        ///////////////
        ///
        if (end_Quest1 == true && end_Quest2 == true && end_Quest3 == true && end_Quest4 == false)
        {
            if (Quest4 == true)
            {
                Text4.SetActive(true);
                TextDone4 = true;
            }
            else
            {
                Text4.SetActive(false);
            }

        }
        else
        {
            Text4.SetActive(false);
        }
        ///////////////////////////
        ///
        if(end_Quest1 == true && end_Quest2 == true && end_Quest3 == true && end_Quest4 == true && end_Quest5 == false)
        {
            if (Quest5 == true)
            {
                Text5.SetActive(true);
                TextDone5 = true;
            }
            else
            {
                Text5.SetActive(false);
            }

        }
        else
        {
            Text5.SetActive(false);
        }
    }

}
