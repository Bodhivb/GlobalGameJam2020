using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractible
{
	public enum ItemType { toolItem };
	public ItemType itemType;

	public Item item;

	public void Interact() { }
	public void Interact(GameObject player)
	{
		if (itemType == ItemType.toolItem)
		{
			PickUpAbility pickUpA = player.GetComponent<PickUpAbility>();
			Debug.Log("pickedUp Tool Item!");
			pickUpA.PickUpItem(this);
		}
	}
}
