using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour , IInteractible{

	public enum ItemType{accesItem,bonusItem,raftItem};
	public ItemType itemType;
	public string name;
	public int weight;
	public int doorId;
	public int bonusPoints;
	public int part;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Interact(){
		Debug.Log ("interact with " + gameObject.name);
		bool pickedUp;
		if (itemType == ItemType.accesItem)
		{
			Debug.Log ("pickedUp AccesItem!");
			pickedUp = InventoryManager.instance.AddItem (new AccesItem (name, weight, doorId));
		}else
			if (itemType == ItemType.raftItem)
		{
			Debug.Log ("pickedUp RaftItem!");
			pickedUp = InventoryManager.instance.AddItem (new RaftItem (name, weight, part));
		}
		else
		{
			Debug.Log ("pickedUp BonusItem!");
			pickedUp = InventoryManager.instance.AddItem (new BonusItem (name, weight, bonusPoints));
		}
		if (pickedUp)
		{
			gameObject.SetActive (false);
		}
	}
}
