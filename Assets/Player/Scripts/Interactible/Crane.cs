using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public ParticleSystem particle;
    public Bucket bucket;
    public AudioSource audio;
    public Transform bucketSpot;
    private void Start()
    {

        particle.enableEmission = false;
    }

    private void Update()
    {
        if (bucket != null)
            if (bucket.dropped)
            {
                bucket.transform.position = bucketSpot.position;
            }
    }
    public void GiveWater()
    {
        if (!audio.isPlaying)
            audio.Play();
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
        audio.Stop();
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
