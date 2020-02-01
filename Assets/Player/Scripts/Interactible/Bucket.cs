using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public int filled
    {
        get
        {
            return m_filled;
        }
        set
        {
            m_filled = value;
            OnFilledChanged();
        }
    }

    private int m_filled = 0;
    public Transform water;
    public bool dropped;
    public BucketInfo bucketInfo;

    void OnFilledChanged()
    {
        bucketInfo.value = filled * 10;
        water.transform.localPosition = Vector3.Lerp(new Vector3(0, 0, 0.09f), new Vector3(0, 0, 0.35f), filled * 0.1f);
    }

}
