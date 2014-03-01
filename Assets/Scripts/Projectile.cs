using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float Speed;
	public Vector3 DirectionRange1;
	public Vector3 DirectionRange2;

	Vector3 direction;
	
	// Use this for initialization
	void Start () 
	{
		// Get a random direction between range1 and range2
		direction.x = Random.Range(DirectionRange1.x, DirectionRange2.x);
		direction.y = Random.Range(DirectionRange1.y, DirectionRange2.y);
		direction.z = 0;

		direction.Normalize();

		rigidbody2D.AddForce(new Vector2(direction.x, direction.y) * Speed * 3.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.localPosition += direction * Speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy(other.gameObject);
		}
	}
}
