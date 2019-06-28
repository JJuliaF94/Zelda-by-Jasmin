using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu] //so that we can use it as Scriptable Object
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int coins;

    public void AddItem(Item itemToAdd)
    {
        //If the Item is a key?
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}


