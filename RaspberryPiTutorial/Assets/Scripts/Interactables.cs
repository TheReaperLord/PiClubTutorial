using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public virtual void Interact()
    {
        // Override by subclass
        Debug.Log("Error: Unassigned interaction");
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Get player component
        PlayerController player = collision.transform.GetComponent<PlayerController>();

        if (player != null)
        {
            player.canInteract = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        // Get player component
        PlayerController player = collision.transform.GetComponent<PlayerController>();

        if (player != null)
        {
            player.canInteract = false;
        }
    }
}
