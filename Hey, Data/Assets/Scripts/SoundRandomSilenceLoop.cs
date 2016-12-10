using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomSilenceLoop : MonoBehaviour {
	public AudioClip clip;
	public AudioSource source;
	public float minTime;
	public float maxTime;

	// Use this for initialization
	void Start () {
		source.clip = clip;
		StartCoroutine (LoopWithSilence());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoopWithSilence(){
		yield return new WaitForSeconds (clip.length + UnityEngine.Random.Range (minTime, maxTime));
		source.Play ();
		StartCoroutine (LoopWithSilence());
	}
}
