using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4 : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public Picked_Quest Picked_Quest;
    public bool End_Dialog;
    public InventoryAlter InventoryAlter;
    public NextClick4 NextClick4;

    public GameObject QuestSpenser4;
    public GameObject QuestSpenser5;

    public static Quest4 instance;


    void Start()
    {
       
    }
    void Update()
    {
        if (EndDialog == true)
        {
            Picked_Quest.Quest4 = true;
            Dialog1.SetActive(false);
        }
        if (End_Dialog == true)
        {
            Picked_Quest.Quest4 = false;
            Dialog1.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(Picked_Quest.end_Quest4);
            if (Picked_Quest.end_Quest4 == false)
            {
                Dialog1.SetActive(true);

            }
            if (Picked_Quest.TextDone4 == true)

            {
                Dialog1.SetActive(false);
                if (InventoryAlter.unbornPotion > 0)
                {

                    InventoryAlter.Coin += 10;
                    InventoryAlter.DrawCoinUI();
                    Picked_Quest.end_Quest4 = true;

                    Dialog2.SetActive(true);
                    InventoryAlter.unbornPotion -= 1;
                    InventoryAlter.DrawFirePotionUI();
                    Picked_Quest.end_Quest5 = true;
                    Picked_Quest.TextDone5 = true;
                    QuestSpenser5.SetActive(true);
                    QuestSpenser4.SetActive(false);
                    

                }
            }

        }
    }
}
