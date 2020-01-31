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


    [Range(1, 10)]
    public int repairDuration = 3;
    private Coroutine repairCoroutine = null;

    [Header("Item that needed to be repair")]
    public Item repairItem;

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
        Defect();
    }

    public void Defect()
    {
        //Check if object can go break
        if (objectHealth == ObjectHealth.good)
        {
            objectHealth = ObjectHealth.defect;

            onObjectDefect?.Invoke();

            StartCoroutine(DefectTimer(nextHappingTime));
        }
    }

    public void Repair(Item tool)
    {
        //Check if object is broke && can make it with selected tool?
        if (objectHealth == ObjectHealth.defect && tool == repairItem)
        {
            objectHealth = ObjectHealth.making;

            repairCoroutine = StartCoroutine(RepairTimer(repairDuration));

        }
    }

    public void CanceldRepair()
    {
        if (repairCoroutine != null)
        {
            StopCoroutine(repairCoroutine);
            repairCoroutine = null;

            if (objectHealth == ObjectHealth.making)
            {
                objectHealth = ObjectHealth.defect;
            }
        }
    }


    IEnumerator DefectTimer(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
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

    IEnumerator RepairTimer(int duration)
    {
        yield return new WaitForSeconds(duration);
        objectHealth = ObjectHealth.good;
        repairCoroutine = null;
    }
}
