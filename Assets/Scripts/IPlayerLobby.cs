[System.Serializable]
public class IPlayerLobby
{
    public int playerInput;

    public int repairCount;
    public int deathCount;

    public IPlayerLobby (int playerInput)
    {
        this.playerInput = playerInput;
        this.repairCount = 0;
        this.deathCount = 0;
    }
}
