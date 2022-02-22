using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracableObject : MonoBehaviour
{
    [SerializeField] private Item requireItem;

    public virtual void Interact()
    {
        ObjectAction();
    }

    public void ShowOutline()
    {

    }

    public void HideOutline()
    {

    }

    protected virtual void ObjectAction()
    {

    }
}
