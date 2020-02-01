using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabToSpawn;
    GameObject spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, null);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == spawned)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.0f);
        spawned = Instantiate(spawned, transform.position, transform.rotation, null);
    }
}
