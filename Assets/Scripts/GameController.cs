using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Awake () 
    {
        DontDestroyOnLoad(gameObject);
        if (Application.loadedLevel == 0)
            StartCoroutine(OneOrTwoPlayers());
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    IEnumerator OneOrTwoPlayers()
    {
        bool selected = false;
        while (!selected)
        {

            yield return null;
        }
    }
}
