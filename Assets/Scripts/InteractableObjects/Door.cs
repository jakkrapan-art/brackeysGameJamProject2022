using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interacable
{
    [SerializeField] private Door connectedDoor;
    [SerializeField] private Transform spawnTransform;

    public Vector2 SpawnPosition
    {
        get
        {
            return spawnTransform.position;
        }
    }

    protected override void Start()
    {
        base.Start();
        objectActions += MoveToTargetPosition;
    }

    public override void Interact()
    {
        base.Interact();
    }

    private void MoveToTargetPosition()
    {
        player.transform.position = connectedDoor.SpawnPosition;
    }

    protected override void CheckPlayerInRange()
    {
        base.CheckPlayerInRange();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void OnMouseExit()
    {
        base.OnMouseExit();
    }

    protected override void OnMouseOver()
    {
        base.OnMouseOver();
    }
}
