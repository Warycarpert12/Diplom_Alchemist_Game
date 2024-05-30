using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Default, Food, Weapon, Armor }
public class ItemScriptableObject : ScriptableObject
{

   public string itemName;
   public ItemType itemType;
   public GameObject itemPrefab;
   public int maximumAmount;
   public string itemDescription;
}
