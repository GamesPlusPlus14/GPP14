using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject goPlayer;

	public List<GameObject> Items = new List<GameObject>();
	public GameObject levelText;
    public GameObject goGUI;
    public GameObject theLips;
    private Transform trnLips;
    private ItemTarget scriptItemTarget;
    private Inventory scriptInv;

	int currentLevel;
	public bool retrievedAllItems;

	void Start()
	{
		retrievedAllItems = false;
        scriptItemTarget = theLips.GetComponent<ItemTarget>();
        trnLips = theLips.transform;
        scriptInv = GameObject.FindWithTag("InventoryManager").GetComponent<Inventory>();
		currentLevel = 1;
	}


	// Use this for initialization
	void Awake ()
    {
        Statics.playerIsDead = false;
        DontDestroyOnLoad(gameObject);
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
        scriptInv.inventory.Clear();
        bool stilldead = true;
        while (stilldead)
        {
            if (Input.GetButtonDown(Statics.AButton))
            {
                DoTheRespawning();
                if (GameObject.FindWithTag("Pickup") == null)
                {
                    int index = Random.Range(0, Items.Count);
                    GameObject targetClone = Instantiate(Items[index], new Vector3(Random.Range(-Statics.widthInUnity / 2, Statics.widthInUnity / 2), Random.Range(-Statics.heightInUnity / 2, Statics.heightInUnity / 2), 0.0f), Quaternion.identity) as GameObject;
                }
                Spawn.ResetTimers();
                currentLevel = 1;
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
        currentLevel++;
        levelText.guiText.text = "Level " + currentLevel.ToString();
        goGUI.SetActive(true);
        retrievedAllItems = false;
        Spawn.UpdateTimers();
        Statics.gamePaused = true;
        Destroy(GameObject.FindWithTag("Player"));
        DoTheRespawning();
        scriptInv.inventory.Clear();
        yield return new WaitForSeconds(3f);
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
