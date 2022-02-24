using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interacable : MonoBehaviour
{
    [SerializeField] private UnityEvent objectActions;
    [SerializeField] private float playerCheckRadius;
    private SpriteRenderer sr;
    private bool isPlayerInRange;
    private Player player;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckPlayerInRange();
    }

    public void Interact()
    {
        if (isPlayerInRange)
        {
            //objectActions.Invoke();
            Debug.Log("Interact!");
        }
    }

    private void CheckPlayerInRange()
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

    private void OnMouseOver()
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

    private void OnMouseExit()
    {
        sr.color = Color.white;
    }

    private void OnMouseDown()
    {
        if (isPlayerInRange)
        {
            Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
