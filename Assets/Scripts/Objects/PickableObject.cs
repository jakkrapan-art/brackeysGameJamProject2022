using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteracableObject
{
    [SerializeField] private Item itemToGet;

    public override void Interact()
    {
        base.Interact();
    }

    protected override void ObjectAction()
    {
        base.ObjectAction();
    }

    
}
