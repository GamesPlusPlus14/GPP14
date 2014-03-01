using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject goPlayer;
	public List<GameObject> Items;
	public GameObject levelText;

	int currentLevel;
	public bool retrievedAllItems;

	void Start()
	{
		levelText = GameObject.FindWithTag("GUIText");
		Items = new List<GameObject>();
		retrievedAllItems = false;

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
			StartCoroutine(Respawn());
			levelText.transform.parent.gameObject.SetActive(true);
			levelText.guiText.text = "Level " + currentLevel.ToString();
			retrievedAllItems = false;

			StartCoroutine(ShutOffGUI());
		}
	}

	IEnumerator ShutOffGUI()
	{
		yield return new WaitForSeconds(3f);
		levelText.transform.parent.gameObject.SetActive(false);
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
                foreach (GameObject go in GameObject.FindGameObjectsWithTag(Statics.Projectile))
                {
                    Destroy(go);
                }
                GameObject clone = Instantiate(goPlayer, Vector3.zero, Quaternion.identity) as GameObject;
                GameObject.FindWithTag(Statics.ViewWindow).transform.position = Vector3.zero;
                stilldead = false;
            }
            yield return null;
        }
    }
}
