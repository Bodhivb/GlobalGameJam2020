﻿using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;


    [Range(5, 10)]
    public int minNextHappeningTime = 7;
    [Range(10, 30)]
    public int maxNextHappeningTime = 20;

    public int nextHappingTime {
        get {
            return UnityEngine.Random.Range(minNextHappeningTime, maxNextHappeningTime);
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogWarning("There is already instance of GameManager in the game");
            Destroy(this);
        }
    }

    #endregion
    private DefectiveObject[] defectives;


    // Start is called before the first frame update
    void Start()
    {
        defectives = FindObjectsOfType<DefectiveObject>();
        StartCoroutine(Timer(nextHappingTime));
    }

    void SpawmRandomDefect()
    {
        if (defectives.Length > 0)
            defectives[Random.Range(0, defectives.Length - 1)].Defect();
    }

    IEnumerator Timer(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        SpawmRandomDefect();
        StartCoroutine(Timer(nextHappingTime));
    }
}
