using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCubeTest : InteractablesTest
{
    public override void Interact()
    {
        Debug.Log("Interaction with Cube");
        transform.position += new Vector3(5, 5, 5);
    }
}
