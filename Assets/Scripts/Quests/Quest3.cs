using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public Picked_Quest Picked_Quest;
    public bool End_Dialog;
    public InventoryAlter InventoryAlter;
    public NextClick3 NextClick3;

    public GameObject QuestSpenser3;
    public GameObject QuestSpenser4;

    void Update()
    {
        if (EndDialog == true)
        {
            Picked_Quest.Quest3 = true;
            Dialog1.SetActive(false);
        }
        if (End_Dialog == true)
        {
            Picked_Quest.Quest3 = false;
            Dialog1.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(Picked_Quest.end_Quest3);
            if (Picked_Quest.end_Quest3  == false)
            {
                Dialog1.SetActive(true);

            }
            if (Picked_Quest.TextDone3 == true)

            {
                Dialog1.SetActive(false);
                if (InventoryAlter.spidPotion > 0)
                {

                    InventoryAlter.Coin += 10;
                    InventoryAlter.DrawCoinUI();
                    Picked_Quest.end_Quest3 = true;

                    Dialog2.SetActive(true);
                    InventoryAlter.spidPotion -= 1;
                    InventoryAlter.DrawSpidPotionUI();
                    QuestSpenser4.SetActive(true);
                    QuestSpenser3.SetActive(false);

                }
            }

        }
    }
}
