using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractible
{
	public enum ItemType { toolItem };
	public ItemType itemType;

	public Item item;


	public void Interact()
	{
		Debug.Log("interact with " + gameObject.name);
		bool pickedUp;
		if (itemType == ItemType.toolItem)
		{
			Debug.Log("pickedUp Tool Item!");
			pickedUp = InventoryManager.instance.AddItem(item);
		}
	}
}
