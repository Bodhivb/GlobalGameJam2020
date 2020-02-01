using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Use only in BoilderRoom scene
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }

    public enum Level
    {
        easy, normal, hard
    }
    public Level currentLevel;


    [Range(5, 10)]
    public int minNextHappeningTime = 7;
    [Range(10, 30)]
    public int maxNextHappeningTime = 20;

    public bool isGameEnd = false;

    public int nextHappingTime
    {
        get
        {
            return UnityEngine.Random.Range(minNextHappeningTime, maxNextHappeningTime);
        }
    }
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

    public void GameOver()
    {
        if (!isGameEnd)
        {
            isGameEnd = true;
            StartCoroutine(CloseScene());
        }
    }

    IEnumerator Timer(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        SpawmRandomDefect();
        StartCoroutine(Timer(nextHappingTime));
    }


    IEnumerator CloseScene()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
