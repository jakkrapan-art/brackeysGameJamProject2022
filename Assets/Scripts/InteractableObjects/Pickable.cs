using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interacable
{
    [SerializeField] private Item itemToGive;

    protected override void Start()
    {
        base.Start();

        objectActions += PickUp;
    }

    private void PickUp()
    {
        GiveItem();
    }

    private void GiveItem()
    {
        Inventory playerInventory = player.GetComponent<Inventory>();

        playerInventory.AddItem(itemToGive);

        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
