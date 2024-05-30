using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UiPanel;
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 4f;
    private Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;
        UiPanel.SetActive(false);

        for (int i = 0; i < InventoryPanel.childCount; i++) 
        { 
            if (InventoryPanel.GetChild(0).GetComponent<InventorySlot>() != null)
            {
                slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                UiPanel.SetActive(true);
            }
            else
            {
                UiPanel.SetActive(false);
            }
        }
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction*reachDistance, Color.green);
            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction*reachDistance, Color.red);
        }

    }
    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if(slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if(slot.isEmpty==false)
            {
                slot.item = _item;
                slot.amount = _amount;
            }
        }
    }
}
