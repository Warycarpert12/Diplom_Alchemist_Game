using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSpenser : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public Picked_Quest Picked_Quest;
    public bool End_Dialog;
    public InventoryAlter InventoryAlter;
    public Dialog_NextClick Dialog_NextClick;
    public GameObject QuestSpenser11;
    public GameObject QuestSpenser22;

     public static QuestSpenser instance;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    void Update()
    {
        if (EndDialog == true)
        {
           // Time.timeScale = 1;
            Picked_Quest.Quest1 = true;
            Dialog1.SetActive(false);
        }
        if (End_Dialog == true)
        {
          //  Time.timeScale = 1;
            Picked_Quest.Quest1 = false;
            Dialog1 .SetActive(false);
        }

    }
    void OnTriggerEnter(Collider col)
        {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
          //  Time.timeScale = 0;
            Debug.Log(Picked_Quest.end_Quest1);
            if (Picked_Quest.end_Quest1 == false)
            {
                Dialog1.SetActive(true);
                
            }
            if (Picked_Quest.TextDone == true)

            {
                Dialog1.SetActive(false);
                if (InventoryAlter.hillPotion > 0)
            {

                    InventoryAlter.Coin += 10;
                    InventoryAlter.DrawCoinUI();
                    
                    Debug.Log("Picked");
                Picked_Quest.end_Quest1 = true;

                Dialog2.SetActive(true);
                Debug.Log("Dialog2 activated");
                InventoryAlter.hillPotion -= 1;
                InventoryAlter.DrawHillPotionUI();
                QuestSpenser22.SetActive(true);
                QuestSpenser11.SetActive(false);
                

                }
            }
           
        }
        }
}
