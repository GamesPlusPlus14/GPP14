using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject ProjPrefab;
	public float Speed;
	Vector3 direction;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{

		}
	}
}
