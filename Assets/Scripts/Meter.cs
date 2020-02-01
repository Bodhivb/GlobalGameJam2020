using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    [SerializeField]
    Transform pointer;
    public float value;

    [SerializeField]
    ParticleSystem whiteSmoke;


    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    public void SetMeter(float value)
    {
        float v = map(value, 0, 100, 0, 360);
        pointer.transform.localRotation = Quaternion.Slerp(pointer.transform.localRotation, Quaternion.Euler(pointer.transform.localRotation.x, pointer.transform.localRotation.y, 180 + v), 1);

        if (value > 95)
        {
            whiteSmoke.startSize = 9;
        }
        else if (value > 75)
        {
            whiteSmoke.startSize = 7;
        }
        else if (value > 50)
        {
            whiteSmoke.startSize  = 5;
        }
        else
        {
            whiteSmoke.startSize = 3;
        }
    }
}
