using UnityEngine;

public class PlayerUIInput : MonoBehaviour
{
    public MainMenu menu;
    public int playerInput;

    public GameObject pressJoin;
    public GameObject joined;

    public GameObject readyText;
    public bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        pressJoin.SetActive(true);
        joined.SetActive(false);
        readyText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Player" + playerInput.ToString() + "Intersect"))
        {
            if (pressJoin.activeSelf)
            {
                pressJoin.SetActive(false);
                joined.SetActive(true);
                readyText.SetActive(true);
                menu.AddPlayer();
            }
        }
    }


}
