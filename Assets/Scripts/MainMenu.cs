using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public int currentPlayers = 0;
    public readonly int minPlayers = 2;

    public UnityEngine.UI.Button playButton;
    public PlayerUI[] playersUI;

    // Start is called before the first frame update
    void Start()
    {
        playButton.interactable = false;
    }

    public void OnPlayerAdd()
    {
        currentPlayers++;
        playersUI[currentPlayers - 1].Join();

        if (currentPlayers >= minPlayers)
        {
            //Game is ready to begin
            playButton.interactable = true;
            playButton.GetComponentInChildren<UnityEngine.UI.Text>().text = "Press enter to play";
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentPlayers >= minPlayers)
            {
                StartGame();
            }
        }

        for (int i = 1; i < 5; i++)
        {
            string s = "Player" + i + "Intersect";
            if (i - 1 < Input.GetJoystickNames().Length)
            {
                bool playstation = "Wireless Controller" == Input.GetJoystickNames()[i - 1];
                if (playstation)
                    s += "P";
            }
            if (Input.GetButtonDown(s))
            {
                if (PlayerManager.instance.playersLobby.FindIndex((player) => player.playerInput == i) >= 0)
                    continue;

                PlayerManager.instance.playersLobby.Add(new IPlayerLobby(i));
                OnPlayerAdd();
            }
        }
    }

    public void StartGame()
    {
        playButton.enabled = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
