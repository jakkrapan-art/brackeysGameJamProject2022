using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequireInteracable : Interacable
{
    [SerializeField] private Item requireItem;
    private Item playerInsertedItem;

    private bool isPlayerInsertedCorrectItem()
    {
        return playerInsertedItem.Equals(requireItem);
    }
}
