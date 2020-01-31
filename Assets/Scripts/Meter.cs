using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    [SerializeField]
    Transform pointer;
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    public void SetMeter(float value)
    {
        float v = map(value, 0, 100, 0, 360);
        pointer.transform.rotation = Quaternion.Slerp(pointer.transform.rotation, Quaternion.Euler(pointer.transform.rotation.x, pointer.transform.rotation.y, 180-v), 1);
    }
}
