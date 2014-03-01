using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject goPlayer;

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
        print("getting to coroutine");

        while (stilldead)
        {
            if (Input.GetButtonDown(Statics.AButton))
            {
                print("Pressed A");
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
