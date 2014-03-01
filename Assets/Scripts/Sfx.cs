using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Sfx : MonoBehaviour {

    private AudioSource mySource;

	// Use this for initialization
	void Start () {
        mySource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Statics.playerIsDead && !mySource.isPlaying)
        {
            mySource.Play();
        }
	}
}
