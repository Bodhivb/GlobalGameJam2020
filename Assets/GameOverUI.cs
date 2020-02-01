using System.Collections;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject highScore;
    public UnityEngine.UI.Text spelersText;
    public UnityEngine.UI.Text scoresText;


    private void Start()
    {
        gameOverText.SetActive(false);
        highScore.SetActive(false);

        spelersText.text = "";
        scoresText.text = "";
    }

    public void GameEnd()
    {
        StartCoroutine(CloseEffect());
    }

    IEnumerator CloseEffect()
    {
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2);
        gameOverText.SetActive(false);
        highScore.SetActive(true);

        scoresText.text = "Repair\t\tDeath";

        for (int i = 0; i < PlayerManager.instance.playersLobby.Count; i++)
        {
            IPlayerLobby p = PlayerManager.instance.playersLobby[i];

            spelersText.text += "\nPlayer " + (i + 1);
            scoresText.text += "\n" + p.repairCount + "\t\t\t\t" + p.deathCount;
        }

        yield return new WaitForSeconds(7);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
