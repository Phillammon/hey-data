using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {
	public Image sky;
	private int counter;
	private int quarter;
	private Color32 dawn;
	private Color32 noon;
	private Color32 dusk;
	private Color32 midnight;

	// Use this for initialization
	void Start () {
		counter = 0;
		quarter = 0;
//		dawn = new Color32 (255, 251, 230, 255);
		noon = new Color32 (0, 191, 255, 255);
		dawn = noon;
//		dusk = new Color32 (253,14,103, 255);
//		midnight = new Color32 (25,25,112,255);
		midnight = new Color32 (0,0,0,255);
		dusk = midnight;
		StartCoroutine (cycleColours());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator cycleColours(){
		counter++;
		if (counter == 32) {
			counter = 0;
			quarter++;
			if (quarter == 4) {
				quarter = 0;
			}
		}
		if (quarter == 0) {
			sky.color = Color32.Lerp (dawn, noon, ((float) counter) / 32f);
		}
		if (quarter == 1) {
			sky.color = Color32.Lerp (noon, dusk, ((float) counter) / 32f);
		}
		if (quarter == 2) {
			sky.color = Color32.Lerp (dusk, midnight, ((float) counter) / 32f);
		}
		if (quarter == 3) {
			sky.color = Color32.Lerp (midnight, dawn, ((float) counter) / 32f);
		}
		yield return new WaitForSeconds (10f);
		StartCoroutine (cycleColours());

	}
}
