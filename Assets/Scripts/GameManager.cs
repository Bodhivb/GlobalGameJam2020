using System.Collections;
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

    public enum Level
    {
        easy, normal, hard
    }
    public Level currentLevel;


    [Range(5, 10)]
    public int minNextHappeningTime = 7;
    [Range(10, 30)]
    public int maxNextHappeningTime = 20;

    public int nextHappingTime
    {
        get
        {
            return UnityEngine.Random.Range(minNextHappeningTime, maxNextHappeningTime);
        }
    }
    private DefectiveObject[] defectives;

    [SerializeField]
    int playersToSpawn = 2;
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    Transform[] spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        defectives = FindObjectsOfType<DefectiveObject>();
        StartCoroutine(Timer(nextHappingTime));

        for (int i = 0; i < playersToSpawn; i++)
        {
            //GameObject g = Instantiate(playerPrefab, spawnPos[i].position, spawnPos[i].rotation, null);
            //g.GetComponent<PlayerController>().player = i + 1;
        }
    }

    void SpawmRandomDefect()
    {
        if (defectives.Length > 0)
            defectives[Random.Range(0, defectives.Length - 1)].Defect();
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        StartCoroutine(CloseScene());
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
