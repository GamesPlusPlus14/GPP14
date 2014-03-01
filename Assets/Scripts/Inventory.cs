using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<string> inventory;

	// Use this for initialization
	void Start () 
	{
		inventory = new List<string>();
	}

	public void AddItem(string item)
	{
		inventory.Add(item);
	}

	public void RemoveItem(string item)
	{
		inventory.Remove(item);
	}
}
