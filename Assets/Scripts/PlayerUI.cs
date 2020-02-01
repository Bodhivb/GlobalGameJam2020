using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public enum PlayerStatus
    {
        None, Joined, Ready
    }

    public PlayerStatus status
    {
        get { return m_status; }
        set { m_status = value; OnStatusChanged(); }
    }
    [SerializeField] private PlayerStatus m_status;

    public GameObject pressJoin;
    public GameObject joined;
    public GameObject readyText;

    private void OnStatusChanged()
    {
        pressJoin.SetActive(false);
        joined.SetActive(false);
        readyText.SetActive(false);
        switch (m_status)
        {
            case PlayerStatus.None:
                pressJoin.SetActive(true);
                break;

            case PlayerStatus.Joined:
                joined.SetActive(true);
                break;

            case PlayerStatus.Ready:
                joined.SetActive(true);
                readyText.SetActive(true);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        status = PlayerStatus.None;
    }

    // When the player is joined
    public void Join()
    {
        status = PlayerStatus.Joined;
    }

}
