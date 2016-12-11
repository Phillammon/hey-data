using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadSheet : MonoBehaviour {
	public Draggable activeSheet;
	public GameObject highlight;
	public Image fill;
	public Text readableText;
	public AudioSource audsrc;
	private Color32 memoColour;
	private Color32 fileColour;
	private Vector3 startPoint;
	private Vector3 raisedPoint;
	private IEnumerator runningSlide;
	private bool raised;
	// Use this for initialization
	void Start () {
		memoColour = new Color32 (246,232,113,255);
		fileColour = new Color32 (255,255,255,255);
		raised = false;
		startPoint = gameObject.transform.localPosition;
		raisedPoint = new Vector3 (startPoint.x, startPoint.y + 400);
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
			readableText.text = activeSheet.text.Replace("\\n", "\n");
			gameObject.GetComponent<Image> ().enabled = true;
			readableText.enabled = true;
			fill.enabled = true;
		} else {
			gameObject.GetComponent<Image> ().enabled = false;
			readableText.enabled = false;
			fill.enabled = false;
			highlight.transform.SetParent (gameObject.transform, true);
			highlight.transform.localPosition = new Vector3 (500,500);
		}
	}

	public void HandleClick(){
		raised = !raised;
		audsrc.Play ();
		if (runningSlide != null) {
			StopCoroutine (runningSlide);
		}
		if (raised) {
			runningSlide = scrollTowards (raisedPoint);
		} else {
			runningSlide = scrollTowards(startPoint);
		}
		StartCoroutine(runningSlide);
	}

	private IEnumerator scrollTowards(Vector3 target){
		Vector3 pos;
		while (true){
			pos = gameObject.transform.localPosition;
			pos = new Vector3 (pos.x + 0.1f*(target.x-pos.x), pos.y + 0.1f*(target.y-pos.y));
			gameObject.transform.localPosition = pos;
			yield return 0;
		}
	}
}
