using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    bool birdSpeaks = false;
    bool birdWasHit = false;
    AudioSource[] birdAudio;
    //public AudioSource retryAudio;
	void Start () {
        birdAudio = GameObject.FindGameObjectWithTag("Bird").GetComponents<AudioSource>();
        //retryAudio = GameObject.FindGameObjectWithTag("RetryButton").GetComponent<AudioSource>();
	}
	
	
	void Update () {
		if(birdAudio[0]!=null && birdSpeaks)
        {
            if (Input.GetMouseButtonDown(0)) birdAudio[0].Play();
        }
	}

    public void StartGame()
    {
        birdSpeaks = true;
    }

    public void BirdHit()
    {
        if (!birdWasHit)
        {
            birdSpeaks = false;
            birdAudio[1].Play();
            birdWasHit = true;
        }
    }
}
