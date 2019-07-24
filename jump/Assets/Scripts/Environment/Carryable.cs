using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : Interactable
{
    //When player Presses interact button get parented to players projectile component
    public override void Interact()
    {
        base.Interact();
        pickupObject pickup = FindObjectOfType<pickupObject>();
        pickup.target = gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<NPMovementComponent>())
        //{
        //    collision.gameObject.GetComponent<NPMovementComponent>().stunned = true;
        //}
    }
}
