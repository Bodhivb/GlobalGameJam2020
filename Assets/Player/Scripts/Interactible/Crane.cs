using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public ParticleSystem particle;
    public Bucket bucket;
    private void Start()
    {

        particle.enableEmission = false;
    }
    public void GiveWater()
    {
        particle.enableEmission = true;
        StopAllCoroutines();
        StartCoroutine(TurnOffWater());
        if (bucket != null)
        {
            bucket.filled += 1;
            if (bucket.filled > 10)
                bucket.filled = 10;
        }
    }
    IEnumerator TurnOffWater()
    {
        yield return new WaitForSeconds(1.0f);
        particle.enableEmission = false;
    }
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
