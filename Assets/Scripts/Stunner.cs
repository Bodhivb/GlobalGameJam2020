using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           StunAbility sa = other.GetComponent<StunAbility>();
            if (sa != null)
                sa.Stun();
        }
    }
}
