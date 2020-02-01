﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunner : MonoBehaviour, IInteractible
{
    public Item antiObject;
    PickUpAbility pa;

    public void Interact()
    {
        if (this.gameObject != null)
            Destroy(this.gameObject);
    }
    public void Interact(GameObject player)
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pa = other.GetComponent<PickUpAbility>();
            if (pa != null)
            {
                if (pa.hasItem)
                {
                    if (pa.pickUpItem.item == antiObject)
                    {
                        return;
                    }
                }
            }
            StunAbility sa = other.GetComponent<StunAbility>();
            if (sa != null)
                sa.Stun();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pa = null;
        }
    }
}
