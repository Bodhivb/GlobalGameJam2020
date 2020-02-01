using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public int filled = 0;
    public Transform water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      water.transform.localPosition =  Vector3.Lerp(new Vector3(0, 0, 0.09f), new Vector3(0, 0, 0.35f), filled * 0.01f);
    }
}
