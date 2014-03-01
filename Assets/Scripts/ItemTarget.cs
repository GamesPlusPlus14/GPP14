using UnityEngine;
using System.Collections;

public class ItemTarget : MonoBehaviour {
	
	public string ItemToReceive;
	Inventory inven;
	GameController gc;

	// Use this for initialization
	void Start () {
		inven = GameObject.FindGameObjectWithTag(Statics.InventoryManager).GetComponent<Inventory>();
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
				gc.retrievedAllItems = true;
			}
		}
	}
}
