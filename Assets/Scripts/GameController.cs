using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject goPlayer;

	public List<GameObject> Items;
	public GameObject levelText;
    public GameObject goGUI;
    public GameObject theLips;
    private Transform trnLips;
    private ItemTarget scriptItemTarget;

	int currentLevel;
	public bool retrievedAllItems;

	void Start()
	{
		Items = new List<GameObject>();
		retrievedAllItems = false;
        scriptItemTarget = theLips.GetComponent<ItemTarget>();
        trnLips = theLips.transform;
		currentLevel = 0;
	}


	// Use this for initialization
	void Awake ()
    {
        Statics.playerIsDead = false;
        DontDestroyOnLoad(gameObject);
        //if (Application.loadedLevel == 0)
        //{
        //    StartCoroutine(OneOrTwoPlayers());
        //}
        //else
        //{

        //}
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Statics.playerIsDead)
        {
            StartCoroutine(Respawn());
            Statics.playerIsDead = false;
        }

		// Check if the player reached a new level
		if (retrievedAllItems)
		{
            StartCoroutine(NextLevel());
		}
	}

    IEnumerator OneOrTwoPlayers()
    {
        bool selected = false;
        bool twoPlayer = true;
        while (!selected)
        {
            if (Input.GetButtonDown(Statics.AButton))
            {
                if (twoPlayer)
                    twoPlayer = false;
                else
                    twoPlayer = true;
                }
            yield return null;
        }
    }

    IEnumerator Respawn()
    {
        bool stilldead = true;
        while (stilldead)
        {
            if (Input.GetButtonDown(Statics.AButton))
            {
                DoTheRespawning();
                stilldead = false;
            }
            yield return null;
        }
    }

    void DoTheRespawning()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(Statics.Projectile))
        {
            Destroy(go);
        }
        GameObject clone = Instantiate(goPlayer, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject.FindWithTag(Statics.ViewWindow).transform.position = Vector3.zero;
    }

    IEnumerator NextLevel()
    {
        goGUI.SetActive(true);
        levelText.guiText.text = "Level " + currentLevel.ToString();
        retrievedAllItems = false;
        Spawn.UpdateTimers();
        Statics.gamePaused = true;
        Destroy(GameObject.FindWithTag("Player"));
        yield return new WaitForSeconds(3f);
        DoTheRespawning();
        Statics.gamePaused = false;
        levelText.transform.parent.gameObject.SetActive(false);
        SpawnNewItemAndLips();
    }

    void SpawnNewItemAndLips()
    {
        int index = Random.Range(0, Items.Count);
        GameObject targetClone = Instantiate(Items[index], new Vector3(Random.Range(-Statics.widthInUnity / 2, Statics.widthInUnity / 2), Random.Range(-Statics.heightInUnity / 2, Statics.heightInUnity / 2), 0.0f), Quaternion.identity) as GameObject;
        trnLips.position = new Vector3(Random.Range(-Statics.widthInUnity / 2, Statics.widthInUnity / 2), Random.Range(-Statics.heightInUnity / 2, Statics.heightInUnity / 2), 0.0f);
        scriptItemTarget.ItemToReceive = Items[index].gameObject.name;
    }
}
