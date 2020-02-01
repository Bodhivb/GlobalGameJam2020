using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;

        transform.position = new Vector3(target.x, target.y - 1f, target.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        if (transform.position.y > 0.1f)
        {
            Destroy(this);
        }
    }
}
