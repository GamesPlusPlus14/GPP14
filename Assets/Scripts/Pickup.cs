using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour {

	Inventory inven;

	// Use this for initialization
	void Start () 
	{
		inven = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Pickup")
		{
			inven.AddItem(other.gameObject);
			Destroy(other.gameObject);
		}
	}
}
