using UnityEngine;
using System.Collections;

public class ItemTarget : MonoBehaviour {
	
	public string ItemToReceive;
	Inventory inven;

	// Use this for initialization
	void Start () {
		inven = GameObject.FindGameObjectWithTag(Statics.InventoryManager).GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (inven.inventory.Contains(ItemToReceive))
			{
				inven.RemoveItem(ItemToReceive);
			}
		}
	}
}
