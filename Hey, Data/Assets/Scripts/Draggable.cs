using UnityEngine;
using System.Collections;
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

	public void Grab()
	{
		currpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, currpoint.z));
		audsrc.Play ();
		if (cabinet != null) {
			cabinet.containedFiles.Remove (gameObject);
		}
		gameObject.transform.SetParent (workingArea);
	}

	public void Drag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, currpoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;

	}

	public void Drop(){
		audsrc.Play ();
	}

	public void MouseOn(){
		reader.activeSheet = this;
	}

}