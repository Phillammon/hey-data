using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour {

	// Use this for initialization
	public Sprite mutesprite;
	public Sprite unmutesprite;
	public Button button;
	private bool muted;
	void Start () {
		muted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleSound(){
		muted = !muted;
		AudioListener.volume = 1f - AudioListener.volume;
		if (muted) {
			button.image.sprite = mutesprite; 
		}
		else {
			button.image.sprite = unmutesprite; 
		}
	}
}
