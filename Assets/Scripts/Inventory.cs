using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<GameObject> inventory;

	// Use this for initialization
	void Start () 
	{
		inventory = new List<GameObject>();
	}

	public void AddItem(GameObject item)
	{
		inventory.Add(item);
	}

	public void RemoveItem(GameObject item)
	{
		inventory.Remove(item);
	}
}
