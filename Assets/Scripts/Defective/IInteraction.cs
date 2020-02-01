public interface IInteraction
{
    void Defect();

    void Repair(Item tool, int playerInput);
    void CanceldRepair();
}
