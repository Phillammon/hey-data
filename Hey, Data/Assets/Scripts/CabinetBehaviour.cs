using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetBehaviour : MonoBehaviour {
	public GameObject btn;
	public Transform cabinet;
	public Transform openCabinet;
	public AudioSource src;
	public AudioClip openclip;
	public AudioClip closeclip;
	public AudioClip vrmclip;
	private Vector3 startpos;
	private Vector3 mouseover;
	private bool open;
	private bool ajar;
	private bool lockout;
	public List<GameObject> containedFiles;
	// Use this for initialization
	void Start () {
		Physics.queriesHitTriggers = true;
		startpos = btn.transform.localPosition;
		mouseover = new Vector3 (startpos.x, startpos.y - 10, startpos.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (open) {
			btn.transform.SetParent(openCabinet, true);
			btn.transform.localPosition = new Vector3 (startpos.x, startpos.y - (10 * (2 + containedFiles.Count)), startpos.z);
			for (int i = 0; i < containedFiles.Count; i++) {
				containedFiles[i].transform.localPosition = new Vector3 (startpos.x, startpos.y - (10 * i) -5, startpos.z);
				
			}
		} else if (ajar && !lockout) {
			btn.transform.SetParent(cabinet, true);
			btn.transform.localPosition = mouseover;
		} else {
			btn.transform.SetParent(cabinet, true);
			btn.transform.localPosition = startpos;
		}
	}

	public void MouseOn(){
		if (!open) {
			ajar = true;
			if (!lockout) {
				src.clip = openclip;
				src.Play ();
			}
		}
	}

	public void MouseOff(){
		if (!open) {
			ajar = false;
			if (!lockout) {
				src.clip = closeclip;
				src.Play ();
			}
		}
	}

	public void MouseClicked(){
		open = !open;
		if (!lockout) {
			lockout = true;
			StartCoroutine (VrmmSound ());
		}
	}

	private IEnumerator VrmmSound(){
		src.clip = vrmclip;
		src.Play ();
		yield return new WaitForSeconds (vrmclip.length);
		if (!open) {
			src.clip = closeclip;
			src.Play ();
			yield return new WaitForSeconds (closeclip.length);
			if (ajar) {
				src.clip = openclip;
				src.Play ();
			}
		}
		lockout = false;
	}
}
