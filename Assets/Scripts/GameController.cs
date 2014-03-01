using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject goBoundingBox;


	// Use this for initialization
	void Awake () 
    {

        print("Height in Unity " + Statics.heightInUnity + "  Width in Unity " + Statics.widthInUnity);
        DontDestroyOnLoad(gameObject);
        if (Application.loadedLevel == 1)
        {
            StartCoroutine(OneOrTwoPlayers());
        }
        else
        {
            GameObject cloneWest = Instantiate(goBoundingBox, new Vector3((-Statics.widthInUnity/2.0f) - 1.0f, 0.0f, -1.0f), Quaternion.identity) as GameObject;
            cloneWest.GetComponent<BoxCollider2D>().size = new Vector2(2.0f, Statics.heightInUnity);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
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
}
