using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDump : MonoBehaviour, IInteractible
{
   // [HideInInspector]
    public Bucket bucket;
    public Reactor reactor;
    public void Interact()
    {
        if (bucket != null)
        {
            reactor.waterLevel += (float)bucket.filled;
            bucket.filled = 0;
        }
    }
    public void Interact(GameObject player)
    { }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            bucket = other.GetComponent<Bucket>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            if (other.GetComponent<Bucket>() == bucket)
                bucket = null;
        }
    }
}