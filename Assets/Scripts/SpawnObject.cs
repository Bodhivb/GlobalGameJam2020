using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float sizeSpawn = 3f;


    public void Spawn()
    {
        Instantiate(obj, new Vector3(
            transform.position.x + Random.Range(-sizeSpawn, sizeSpawn),
            transform.position.y,
            transform.position.z + Random.Range(-sizeSpawn, sizeSpawn)),
            Quaternion.identity);
    }
}
