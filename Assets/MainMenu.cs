using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public int currentPlayers = 0;
    public readonly int minPlayers = 2;

    public UnityEngine.UI.Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.interactable = false;
    }

    public void AddPlayer()
    {
        currentPlayers++;
        if (currentPlayers >= minPlayers)
        {
            //Game is ready to begin
            playButton.interactable = true;
            playButton.GetComponentInChildren<UnityEngine.UI.Text>().text = "Press enter to play";
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentPlayers >= minPlayers)
            {
                StartGame();
            }
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
