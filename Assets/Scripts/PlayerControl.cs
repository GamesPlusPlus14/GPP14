using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float playerSpeed = 5.0f;
    public float windowSpeed = 10.0f;
    private float aspect = Screen.width / Screen.height;
    private float height = .5f;
    private float width;
    private Transform transPlayer;
    private Transform transCamera;

	// Use this for initialization
	void Start () 
    {
        // Localizing the transforms
        transPlayer = transform;
        transCamera = Camera.main.transform;

        // Get the width from the height and aspect
        width = height / aspect;
        // Set the viewport to a square
        Camera.main.aspect = 1 / 2;
	}
	
	// Update is called once per frame
	void Update () 
    {
        HandleInput();
	}

    void HandleInput()
    {
        transPlayer.position = new Vector3(Input.GetAxisRaw(Statics.PHorz), Input.GetAxisRaw(Statics.PVert), 0.0f).normalized * playerSpeed;
        transCamera.position = new Vector3(Input.GetAxisRaw(Statics.WHorz), Input.GetAxisRaw(Statics.WVert), 0.0f).normalized * windowSpeed;
    }
}
