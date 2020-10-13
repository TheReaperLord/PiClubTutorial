using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesTest : MonoBehaviour
{
    PlayerControllerTest player = null;

    void OnTriggerEnter(Collider collision)
    {
        if (player == null)
        {
            PlayerControllerTest player = collision.transform.GetComponent<PlayerControllerTest>();

            if (player != null)
            {
                Debug.Log(player);
                player.canInteract = true;
            }
        } else
        {
            player.canInteract = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (player == null)
        {
            PlayerControllerTest player = collision.transform.GetComponent<PlayerControllerTest>();

            if (player != null)
            {
                Debug.Log(player);
                player.canInteract = false;
            }
        }
        else
        {
            player.canInteract = false;
        }
    }

    public virtual void Interact()
    {
        // designed to be overwritten by subclasses
    }
}
