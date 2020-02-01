using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    Light light;
    int intensity = 0;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        timer = Random.Range(2, 5);
        intensity = Random.Range(10, 16);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = Random.Range(2, 5);
            intensity = Random.Range(10, 16);
        }
        light.intensity = Mathf.Lerp(light.intensity, intensity, 0.5f);
    }
}
