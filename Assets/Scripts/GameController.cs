using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject goBoundingBox;
    private float heightInUnity;
    private float widthInUnity;


	// Use this for initialization
	void Awake () 
    {
        heightInUnity = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y - Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        widthInUnity = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x - Camera.main.ScreenToWorldPoint(Vector3.zero).x;

        print("Height in Unity " + heightInUnity + "  Width in Unity " + widthInUnity);
        DontDestroyOnLoad(gameObject);
        if (Application.loadedLevel == 1)
        {
            StartCoroutine(OneOrTwoPlayers());
        }
        else
        {
            GameObject cloneWest = Instantiate(goBoundingBox, new Vector3((-widthInUnity/2.0f) - 1.0f, 0.0f, -1.0f), Quaternion.identity) as GameObject;
            cloneWest.GetComponent<BoxCollider2D>().size = new Vector2(2.0f, heightInUnity);
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
