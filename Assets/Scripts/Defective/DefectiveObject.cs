using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DefectiveObject : MonoBehaviour, IInteraction
{
    [Header("Object status")]
    public ObjectHealth objectHealth;
    public enum ObjectHealth
    {
        good, defect, making
    }

                                    
    [Header("onHealthChanged effect")]
    public UnityEvent onObjectDefect;
    public UnityEvent onObjectRepair;


    [Header("The event of broke object")]
    [Range(5, 10)]
    public int minNextHappeningTime = 7;

    [Range(10, 30)]
    public int maxNextHappeningTime = 20;

    public UnityEvent defectEvent;


    public enum objectType
    {
        pipe, powerbox, cable
    }


    public int nextHappingTime
    {
        get
        {
            return UnityEngine.Random.Range(minNextHappeningTime, maxNextHappeningTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        onDefect();
    }

    public void Defect()
    {
        onDefect();
    }

    public void onDefect()
    {
        Debug.Log("Object goes defect");

        //Check if object can go break
        if (objectHealth == ObjectHealth.good)
        {
            objectHealth = ObjectHealth.defect;

            onObjectDefect?.Invoke();

            StartCoroutine(DefectTimer(nextHappingTime));
        }
    }


    IEnumerator DefectTimer(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        Debug.Log("Defect effect");
        switch (objectHealth)
        {
            case ObjectHealth.defect:
                defectEvent?.Invoke();
                StartCoroutine(DefectTimer(nextHappingTime));

                break;

            case ObjectHealth.making:
                StartCoroutine(DefectTimer(nextHappingTime));
                break;

            default:
                break;
        }
    }
}
