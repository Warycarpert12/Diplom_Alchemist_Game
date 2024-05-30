using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest5 : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public Picked_Quest Picked_Quest;
    public bool End_Dialog;
    public InventoryAlter InventoryAlter;
    public NextClick5 NextClick5;

    public GameObject QuestSpenser4;
    public GameObject QuestSpenser5;

    public static Quest5 instance;
    public DoNotDestroi notDestroi;

    void Start()
    {

    }
    void Update()
    {
        if (EndDialog == true)
        {
            Picked_Quest.Quest5 = true;
            Dialog1.SetActive(false);
        }
        if (End_Dialog == true)
        {
            Picked_Quest.Quest5 = false;
            Dialog1.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(Picked_Quest.end_Quest5);
            if (Picked_Quest.end_Quest5 == false)
            {
                Dialog1.SetActive(true);
            }
            if (Picked_Quest.TextDone5 == true)
            {
                Dialog1.SetActive(false);
                Dialog2.SetActive(true);
                Invoke("DeactivateQuestSpenser5", 3f);
                Invoke("LoadScene5", 3f); 
            }
        }
    }

    void DeactivateQuestSpenser5()
    {
        QuestSpenser5.SetActive(false);
    }
    void LoadScene5()
    {
        notDestroi.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(5); 
    }
}
