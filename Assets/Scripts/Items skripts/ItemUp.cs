using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemUp : MonoBehaviour
{
    public InventoryAlter InventoryAlter;
    public TextMeshProUGUI itemAmountTMP;
    public AudioSource takeOneGrib;
    public AudioSource takeOneFlower;

    public bool gipnoGrib;
    public bool muhomorApetitGrib;
    public bool pogankaObikGrib;
    public bool fireGrib;
    public bool strongestGrib;

    public bool polan;
    public bool boyaresnic;
    public bool borhevic;

    private void Start()
    {
        //DrawSilaGribUI();
        //DrawBorchevicUI();
        //DrawBoyarishnikUI();
        //DrawFireGribUI();
        //DrawGipnoGribUI();
        //DrawPogankaUI();
        //DrawMyhomorUI();
        //DrawPolinUI();


    }
    private void Update()
    {
       
        if (InventoryAlter == null)
        {
            Debug.Log("Doneeee");
            InventoryAlter = GameObject.Find("Inventory").GetComponent<InventoryAlter>();
        }
    
    }

    private void OnTriggerStay(Collider other)
    {
        if ( gipnoGrib == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.gipnoGrib += 1;
                DrawGipnoGribUI();
                Destroy(gameObject);
                takeOneGrib.Play();
            }
        }
        else if (muhomorApetitGrib == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.muhomorApetitGrib += 1;
                DrawMyhomorUI();
                Destroy(gameObject);
                takeOneGrib.Play();
            }
        }
        else if (pogankaObikGrib == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.pogankaObikGrib += 1;
                DrawPogankaUI();
                Destroy(gameObject);
                takeOneGrib.Play();
            }
        }
        else if (fireGrib == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.fireGrib += 1;
                DrawFireGribUI();
                Destroy(gameObject);
                takeOneGrib.Play();
            }
        }
        else if (strongestGrib == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.strongestGrib += 1;
                DrawSilaGribUI();
                Destroy(gameObject);
                takeOneGrib.Play();

            }
        }
        else if (polan == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.polan += 1;
                DrawPolinUI();
                Destroy(gameObject);
                takeOneFlower.Play();
            }
        }
        else if (boyaresnic == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.boyaresnic += 1;
                DrawBoyarishnikUI();
                Destroy(gameObject);
                takeOneFlower.Play();
            }
        }
        else if (borhevic == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryAlter.borhevic += 1;
                DrawBorchevicUI();
                Destroy(gameObject);
                takeOneFlower.Play();
            }
        }
    }
    public void DrawSilaGribUI()
    {
        itemAmountTMP.text = InventoryAlter.strongestGrib.ToString();
    }

    public void DrawMyhomorUI()
    {
        itemAmountTMP.text = InventoryAlter.muhomorApetitGrib.ToString();
    }

    public void DrawPogankaUI()
    {
        itemAmountTMP.text = InventoryAlter.pogankaObikGrib.ToString();
    }

    public void DrawGipnoGribUI()
    {
        itemAmountTMP.text = InventoryAlter.gipnoGrib.ToString();
    }

    public void DrawFireGribUI()
    {
        itemAmountTMP.text = InventoryAlter.fireGrib.ToString();
    }

    public void DrawPolinUI()
    {
        itemAmountTMP.text = InventoryAlter.polan.ToString();
    }

    public void DrawBoyarishnikUI()
    {
        itemAmountTMP.text = InventoryAlter.boyaresnic.ToString();
    }

    public void DrawBorchevicUI()
    {
        itemAmountTMP.text = InventoryAlter.borhevic.ToString();
    }
}
