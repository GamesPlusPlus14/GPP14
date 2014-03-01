using UnityEngine;
using System.Collections;

public class ItemTarget : MonoBehaviour {
	
	public string ItemToReceive;
	Inventory inven;
<<<<<<< HEAD
	GameController gc;
=======
    private AudioSource mySource;
>>>>>>> 8defcb5dd29e038252edcb4d45fa10bcdb6efdea

	// Use this for initialization
	void Start () {
		inven = GameObject.FindGameObjectWithTag(Statics.InventoryManager).GetComponent<Inventory>();
<<<<<<< HEAD
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
=======
        mySource = GetComponent<AudioSource>();
>>>>>>> 8defcb5dd29e038252edcb4d45fa10bcdb6efdea
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
				gc.retrievedAllItems = true;
			}
		}
	}
}
