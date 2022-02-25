using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemRequireInteracable : Interacable
{
    [SerializeField] private Item requireItem;
    private Item playerInsertedItem;
    private bool isPlayerInsertedItem;

    [SerializeField] private UnityAction ActionsWhenInsertedCorrectItem;

    protected override void Start()
    {
        base.Start();

        objectActions += DoItemInsertProcess;
    }

    private void DoCorrectInsertedItemProcess()
    {
        //ActionsWhenInsertedCorrectItem?.Invoke();
        Debug.Log("Correct item inserted.");

        isLocked = true;
    }

    private void DoItemInsertProcess()
    {
        StartCoroutine(ItemInsertProcess());
    }

    private IEnumerator ItemInsertProcess()
    {
        player.DisableMove();
        isLocked = true;
        yield return new WaitForSeconds(5);
        player.playerInventory.InsertItemToInteractableObject(this, player.playerInventory.items[0]);
        yield return new WaitUntil(() => isPlayerInsertedItem);
        if (IsPlayerInsertedCorrectItem())
        {
            player.playerInventory.RemoveItem(playerInsertedItem);
            DoCorrectInsertedItemProcess();
        }
        else
        {
            ResetInsertedItem();
        }

        player.EnableMove();
    }

    public void InsertItem(Item item)
    {
        playerInsertedItem = item;
        isPlayerInsertedItem = true;
    }

    private bool IsPlayerInsertedCorrectItem()
    {
        return playerInsertedItem.Equals(requireItem);
    }

    private void ResetInsertedItem()
    {
        playerInsertedItem = null;
        isPlayerInsertedItem = false;
        isLocked = false;
        Debug.Log("Inserted wrong item!");
    }
}
