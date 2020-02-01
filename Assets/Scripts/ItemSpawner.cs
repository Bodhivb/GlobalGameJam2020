using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabToSpawn;
    PickUpItem spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, null).GetComponent<PickUpItem>();
    }

    private void GotObject()
    {
        spawned.pickedUp = false;
        StopAllCoroutines();
        StartCoroutine(Respawn());
    }
    private void Update()
    {
        if (spawned.pickedUp)
        {
            GotObject();
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.0f);
        spawned = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, null).GetComponent<PickUpItem>();
    }
}
