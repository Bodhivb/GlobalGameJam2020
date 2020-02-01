using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractible
{
    public enum ItemType { toolItem };
    public ItemType itemType;
    public bool pickedUp = false;
    public Item item;

    public void Interact()
    {
    }
    public void Interact(GameObject player)
    {
        if (itemType == ItemType.toolItem)
        {
            PickUpAbility pickUpA = player.GetComponent<PickUpAbility>();
            Debug.Log("pickedUp Tool Item!");
            this.pickedUp = true;
            pickUpA.PickUpItem(this);
        }
    }
}
