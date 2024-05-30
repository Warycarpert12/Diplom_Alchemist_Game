using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SilaGribCounter : MonoBehaviour
{
    public TextMeshProUGUI itemAmountTMP;
    public InventoryAlter inventoryAlter;

    //private int _max
    private int _itemAmount = 0;

    private float _silaGribCurrentAmountValue = 0;

    private void Start()
    {
        DrawUI();
    }

    public void AddAmount(float value)
    {
        _silaGribCurrentAmountValue += value;
        if (inventoryAlter.strongestGrib == 1)

        DrawUI();
    }

    private void DrawUI()
    {
        itemAmountTMP.text = _itemAmount.ToString();
    }


}
