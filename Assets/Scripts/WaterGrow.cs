using System.Collections;
using UnityEngine;

public class WaterGrow : MonoBehaviour
{
    private int maxBigger = 18;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToGrow(10));
    }


    IEnumerator waitToGrow(int sec)
    {
        yield return new WaitForSeconds(sec);
        transform.localScale = new Vector3(transform.localScale.x + Random.Range(0f, 0.005f), transform.localScale.y, transform.localScale.z + Random.Range(0f, 0.005f));
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(transform.localScale.x + Random.Range(0f, 0.005f), transform.localScale.y, transform.localScale.z + Random.Range(0f, 0.005f));
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(transform.localScale.x + Random.Range(0f, 0.005f), transform.localScale.y, transform.localScale.z + Random.Range(0f, 0.005f));
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(transform.localScale.x + Random.Range(0f, 0.005f), transform.localScale.y, transform.localScale.z + Random.Range(0f, 0.005f));

        if (maxBigger > 0)
        {
            maxBigger--;
            StartCoroutine(waitToGrow(3));
        }
    }
}
