using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingScript : MonoBehaviour
{
    public InventoryAlter InventoryAlter;
    public int a;
    public int b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 7 && b ==5)
        {
            InventoryAlter.hillPotion += 1;
            a = 0;
            b = 0;
            Debug.Log("potion+1");
            InventoryAlter.DrawHillPotionUI();
        }
        if (a == 1 && b == 8)
        {
            InventoryAlter.hipnosisPotion += 1;
            a = 0;
            b = 0;
            Debug.Log("potion+1");
            InventoryAlter.DrawHipnosisPotionUI();
        }
        if (a == 5 && b == 8)
        {
            InventoryAlter.strongestPotion += 1;
            a = 0;
            b = 0;
            Debug.Log("potion+1");
            InventoryAlter.DrawSilaPotionUI();
        }
        if (a == 6 && b == 3)
        {
            InventoryAlter.poisonPotion += 1;
            a = 0;
            b = 0;
            Debug.Log("potion+1");
            InventoryAlter.DrawPoisonPotionUI();
        }
        if (a == 6 && b == 4)
        {
            InventoryAlter.unbornPotion += 1;
            a = 0;
            b = 0;
            Debug.Log("potion+1");
            InventoryAlter.DrawFirePotionUI();
        }
        if (a == 7 && b == 3)
        {
            InventoryAlter.spidPotion += 1;
            a = 0;
            b = 0;
            Debug.Log("potion+1");
            InventoryAlter.DrawSpidPotionUI();
        }
    }
   
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "BoyarishnikFlower(Clone)")
        {
             a = 7;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "PogankaMush(Clone)")
        {
            b = 3;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "GipnoMush(Clone)")
        {
            a = 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "BorchevikFlower(Clone)")
        {
            b = 8;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "SilaMush(Clone)")
        {
            a = 5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "PolinFlower(Clone)")
        {
            a = 6;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "FireMush(Clone)")
        {
            b = 4;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "MyhomorMush(Clone)")
        {
            b = 5;
            Destroy(other.gameObject);
        }





    }
}
