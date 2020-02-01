using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += this.OnLevelStart;
        }
        else
        {
            Debug.LogWarning("There is already instance of PlayerManager in the game");
            Destroy(this);
        }
    }

    #endregion


    public List<IPlayerLobby> playersLobby = new List<IPlayerLobby>();

    public List<Transform> spawnPos;


    [SerializeField] private UnityEngine.Object playerPrefab;
    public List<GameObject> players = new List<GameObject>();

    // Start is called before the first frame update
    void OnLevelStart(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == "MainMenu")
        {
  
        }
        else if (scene.name == "BoilerRoom")
        {
            for (int i = 0; i < playersLobby.Count; i++)
            {
                GameObject gb = Instantiate(playerPrefab, spawnPos[i].position, Quaternion.identity) as GameObject;
                gb.GetComponent<PlayerController>().player = playersLobby[i].playerInput;
                gb.name = "Player" + i;

                players.Add(gb);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
   

    }
}
