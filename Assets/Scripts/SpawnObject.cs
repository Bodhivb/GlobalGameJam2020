using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float sizeSpawn = 3f;
    [SerializeField] private Transform target;

    [SerializeField] private GameObject[] defectsObject;


    public void Start()
    {
        defectsObject = new GameObject[11];
    }

    public void Spawn()
    {
        for (int i = 0; i < defectsObject.Length; i++)
        {
            if (defectsObject[i] == null)
            {
                Vector3 pos = Vector3.Lerp(transform.position, target.position, 0.09f * i);

                defectsObject[i] = Instantiate(obj, new Vector3(pos.x + Random.Range(-sizeSpawn, sizeSpawn), pos.y, pos.z + Random.Range(-sizeSpawn, sizeSpawn)), Quaternion.identity) as GameObject;
                return;
            }
        }
    }
}
