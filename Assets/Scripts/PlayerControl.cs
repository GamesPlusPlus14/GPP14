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

	// Use this for initialization
	void Start () 
    {
        aspect = (float)Screen.width / (float)Screen.height;

        // Localizing the transforms
        transPlayer = transform;
        transWindow = GameObject.FindWithTag(Statics.ViewWindow).transform;

	}
	
	// Update is called once per frame
	void Update () 
    {
        HandleInput();
	}

    void HandleInput()
    {
        transPlayer.position += new Vector3(Input.GetAxisRaw(Statics.PHorz), Input.GetAxisRaw(Statics.PVert), 0.0f).normalized * playerSpeed * Time.deltaTime;
        if (Statics.onePlayer)
            transWindow.position += new Vector3(Input.GetAxisRaw(Statics.WHorz1), Input.GetAxisRaw(Statics.WVert1), 0.0f).normalized * windowSpeed * Time.deltaTime;
        else
            transWindow.position += new Vector3(Input.GetAxisRaw(Statics.WHorz), Input.GetAxisRaw(Statics.WVert), 0.0f).normalized * windowSpeed * Time.deltaTime;
    }
}
