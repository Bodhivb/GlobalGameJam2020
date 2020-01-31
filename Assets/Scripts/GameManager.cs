using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

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



    [SerializeField] private Meter meter;

    private DefectiveObject[] defectives;


    // Start is called before the first frame update
    void Start()
    {
        defectives = FindObjectsOfType<DefectiveObject>();
        SpawmRandomDefect();
    }

    // Update is called once per frame
    void Update()
    {
        meter.SetMeter(Time.time);
    }

    void SpawmRandomDefect()
    {
        if (defectives.Length > 0)
            defectives[Random.Range(0, defectives.Length - 1)].Defect();
    }
}
