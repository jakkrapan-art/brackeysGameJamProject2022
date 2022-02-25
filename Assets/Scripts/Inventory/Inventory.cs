using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items { get; private set; } = new List<Item>();

    public void AddItem(Item item)
    {
        if (item)
        {
            items.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        if (item)
        {
            items.Remove(item);
        }
    }

    public void ShowInventory()
    {
        //TODO: Implement method.
    }

    public void InspectItem(int index)
    {
        items[index].ShowDetail();
    }

    public void InsertItemToInteractableObject(ItemRequireInteracable targetObject, Item itemToInsert)
    {
        targetObject.InsertItem(itemToInsert);
    }
}
