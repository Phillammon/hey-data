using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(MeshCollider))]

public class Draggable : MonoBehaviour 
{

	private Vector3 currpoint;
	private Vector3 offset;
	public AudioSource audsrc;
	public ReadSheet reader;
	public CabinetBehaviour cabinet;
	public Transform workingArea;
	public bool isMemo;
	public List<CabinetBehaviour> cabinets;

	public void Grab()
	{
		gameObject.transform.SetParent (workingArea);
		currpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		if (cabinet != null) {
			cabinet.containedFiles.Remove (gameObject);
		}
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, currpoint.z));
		audsrc.Play ();
	}

	public void Drag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, currpoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;

	}

	public void Drop(){
		audsrc.Play ();
		for (int i = 0; i < cabinets.Count; i++) {
			cabinets [i].addItem (gameObject);
		}
	}

	public void MouseOn(){
		reader.activeSheet = this;
	}

	public void Disable(){
		if (reader.activeSheet == this) {
			reader.activeSheet = null;
		}
	}

}