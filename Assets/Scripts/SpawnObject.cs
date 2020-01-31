using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private int sizeSpawn = 3;


    public void Spawn()
    {
        Instantiate(obj, new Vector3(
            this.transform.position.x + Random.Range(-sizeSpawn, sizeSpawn),
            this.transform.position.y,
            this.transform.position.z + Random.Range(-sizeSpawn, sizeSpawn)),
            Quaternion.identity);
    }
}
