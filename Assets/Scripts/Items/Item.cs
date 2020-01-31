using UnityEngine;
[System.Serializable]
public abstract class Item : ScriptableObject
{
	//properties

	[SerializeField] private string name = "";
	[SerializeField] private int weight = 0;

	public string Name
	{
		get
		{
			return name;
		}
	}

	public int Weight
	{
		get
		{
			return weight;
		}
	}

	//contructor
	public Item(string name,int weight)
	{
		this.name = name;
		this.weight = weight;
	}


	//methods
}
