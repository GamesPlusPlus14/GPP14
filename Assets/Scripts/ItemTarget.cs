using UnityEngine;
using System.Collections;

public class ItemTarget : MonoBehaviour {
	
	public string ItemToReceive;
	Inventory inven;
    private AudioSource mySource;

	// Use this for initialization
	void Start () {
		inven = GameObject.FindGameObjectWithTag(Statics.InventoryManager).GetComponent<Inventory>();
        mySource = GetComponent<AudioSource>();
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
                mySource.Play();
				inven.RemoveItem(ItemToReceive);
			}
		}
	}
}
