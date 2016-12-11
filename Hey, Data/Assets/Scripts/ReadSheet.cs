using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadSheet : MonoBehaviour {
	public Draggable activeSheet;
	public GameObject highlight;
	public Image fill;
	public Text readableText;
	private Color32 memoColour;
	private Color32 fileColour;
	// Use this for initialization
	void Start () {
		memoColour = new Color32 (246,232,113,255);
		fileColour = new Color32 (255,255,255,255);
	}
	
	// Update is called once per frame
	void Update () {
		if (activeSheet != null) {
			highlight.transform.SetParent (activeSheet.gameObject.transform, true);
			highlight.transform.localPosition = new Vector3 (0, 38);
			highlight.transform.SetAsFirstSibling ();
			if (activeSheet.isMemo) {
				fill.color = memoColour;
			} else {
				fill.color = fileColour;
			}
			gameObject.GetComponent<Image> ().enabled = true;
			readableText.enabled = true;
			fill.enabled = true;
		} else {
			gameObject.GetComponent<Image> ().enabled = false;
			readableText.enabled = false;
			fill.enabled = false;
		}
	}
}
