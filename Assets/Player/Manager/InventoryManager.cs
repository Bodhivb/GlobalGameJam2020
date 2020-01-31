using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	public static InventoryManager instance;

	//properties
	public int weightLimit = 20;
	public List<Item> inventory;
	int currentWeight = 0;

	//methods
	void Awake(){
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
			inventory = new List<Item> ();
		}
		else
		{
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		/*
		//Debug
		AccesItem i = new AccesItem ("TestBazooka", 10, 1);
		BonusItem b = new BonusItem ("bonus", 1, 10);
		AddItem (i);
		inventory.Add (i);
		inventory.Add (b);
		inventory.Add (b);

		Print ();*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool AddItem(Item item){
		if (currentWeight + item.Weight <= weightLimit)
		{
			inventory.Add (item);
			return true;
		}	
		return false;
	}
	public bool RemoveItem(Item item){
		bool succes = inventory.Remove (item);
		if (succes)
		{
			currentWeight -= item.Weight;
		}
		return succes;
	}
	public void Print(){
		Debug.Log (inventory.Count+" itemsOnInventory");
		for (int i = 0; i < inventory.Count; i++)
		{
			Debug.Log (inventory [i].Name + " name"+i);
		}
	}
}
