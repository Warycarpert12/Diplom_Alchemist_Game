using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ CreateAssetMenuAttribute(fileName = "Food Item", menuName = "Inventory/Items/New Food Item")]
public class FoodItem : ItemScriptableObject
{
   public float healAmount;

    private void Start()
    {
        ItemType type = ItemType.Food;
    }
}
