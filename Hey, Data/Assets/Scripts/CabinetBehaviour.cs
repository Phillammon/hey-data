using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetBehaviour : MonoBehaviour {
	public GameObject btn;
	private Vector3 startpos;
	private Vector3 mouseover;
	// Use this for initialization
	void Start () {
		Physics.queriesHitTriggers = true;
		startpos = btn.transform.localPosition;
		mouseover = new Vector3 (startpos.x, startpos.y - 10, startpos.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MouseOn(){
		btn.transform.localPosition = mouseover;
	}

	public void MouseOff(){
		btn.transform.localPosition = startpos;
	}

	public void MouseClicked(){
	}
}
