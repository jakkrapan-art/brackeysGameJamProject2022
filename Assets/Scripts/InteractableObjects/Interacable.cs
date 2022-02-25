using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interacable : MonoBehaviour
{
    [SerializeField] protected UnityAction objectActions;
    [SerializeField] protected float playerCheckRadius;
    protected SpriteRenderer sr;
    protected bool isPlayerInRange;
    protected Player player;

    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        CheckPlayerInRange();
    }

    public virtual void Interact()
    {
        if (isPlayerInRange)
        {
            objectActions?.Invoke();
        }
    }

    protected virtual void CheckPlayerInRange()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, playerCheckRadius, transform.up);

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Player playerScript = hit.collider.gameObject.GetComponent<Player>();
                player = playerScript;
                isPlayerInRange = true;
                return;
            }
        }

        isPlayerInRange = false;
        player = null;
    }

    protected virtual void OnMouseOver()
    {
        if (isPlayerInRange)
        {
            sr.color = Color.yellow;
        }
        else
        {
            sr.color = Color.white;
        }
    }

    protected virtual void OnMouseExit()
    {
        sr.color = Color.white;
    }

    protected virtual void OnMouseDown()
    {
        if (isPlayerInRange)
        {
            Interact();
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
