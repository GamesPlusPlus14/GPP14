using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

    public List<GameObject> PrefabToSpawn = new List<GameObject>();
	public float MinSpawnTimer;
	public float MaxSpawnTimer;
	
	float spawnTimer;
	float timer;

	// Use this for initialization
	void Start () 
	{
		spawnTimer = Random.Range(MinSpawnTimer, MaxSpawnTimer);
		// Debugging (check if min is greater than max)
		if (MinSpawnTimer > MaxSpawnTimer)
			Debug.Log(gameObject.name + ": The minimum spawn time is greater than the maximum spawn timer.");
		// End debugging

		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if (timer >= spawnTimer)
		{
            int index = Random.Range(0, PrefabToSpawn.Count);
			Instantiate(PrefabToSpawn[index], transform.position, Quaternion.identity);
			timer = 0;
		}

	}
	void OnDrawGizmos()
	{
		Gizmos.DrawIcon(transform.position, "spawnGizmo.png");
	}
}
