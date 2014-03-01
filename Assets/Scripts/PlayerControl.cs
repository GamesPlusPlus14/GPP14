using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float playerSpeed = 5.0f;
    public float windowSpeed = 10.0f;
    private float aspect;
    private float height = 1.0f;
    private float width;
    private Transform transPlayer;
    private Transform transWindow;
    private Rigidbody2D rigidWindow;

	// Use this for initialization
	void Start () 
    {
        aspect = (float)Screen.width / (float)Screen.height;

        // Localizing the transforms
        transPlayer = transform;
        transWindow = GameObject.FindWithTag(Statics.ViewWindow).transform;
        //rigidWindow = GameObject.FindWithTag(Statics.ViewWindow).GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        HandleInput();
	}

    void HandleInput()
    {

        Vector3 movePlayer = new Vector3(Input.GetAxisRaw(Statics.PHorz), Input.GetAxisRaw(Statics.PVert), 0.0f).normalized * playerSpeed * Time.deltaTime;
        if (NextMoveInBounds(transPlayer, movePlayer, 0.125f, 0.125f))
        {
            transPlayer.position += movePlayer;
        }
                
        Vector3 moveWindow;

        if (Statics.onePlayer)
        {
            moveWindow = new Vector2(Input.GetAxisRaw(Statics.WHorz1), Input.GetAxisRaw(Statics.WVert1)).normalized * windowSpeed * Time.deltaTime;
        }
        else
        {
            moveWindow = new Vector2(Input.GetAxisRaw(Statics.WHorz), Input.GetAxisRaw(Statics.WVert)).normalized * playerSpeed * Time.deltaTime;
        }
       
        if (NextMoveInBounds(transWindow, moveWindow, transWindow.localScale.x/2.0f, transWindow.localScale.y/2.0f))
        {
            transWindow.position += moveWindow;
        }
    }

    bool NextMoveInBounds(Transform trans, Vector3 nextMove, float halfObjWidth, float halfObjHeight)
    {
        if ((trans.position.x + nextMove.x - halfObjWidth >= -Statics.widthInUnity/2.0f) && (trans.position.x + nextMove.x + halfObjWidth < Statics.widthInUnity/2.0f) && (trans.position.y + nextMove.y - halfObjHeight >= -Statics.heightInUnity/2.0f) && (trans.position.y + nextMove.y + halfObjHeight < Statics.heightInUnity/2.0f))
            return true;
        else
            return false;
    }
}
