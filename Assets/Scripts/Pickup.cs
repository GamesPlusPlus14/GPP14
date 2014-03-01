using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour {

    private AudioSource mySource;
	Inventory inven;

	// Use this for initialization
	void Start () 
	{
		inven = GameObject.FindGameObjectWithTag(Statics.InventoryManager).GetComponent<Inventory>();
        mySource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Pickup")
		{
			inven.AddItem(other.gameObject.name);
            mySource.Play();
			Destroy(other.gameObject);
		}
	}
}
