using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour {
	public GameObject menuPane;
	private bool started;
	// Use this for initialization
	void Start () {
		started = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		if (!started) {
			started = true;
			StartCoroutine (FadeText ());
		}
	}

	IEnumerator FadeText()
	{
		CanvasGroup cgroup = menuPane.GetComponent<CanvasGroup> ();
		float aTime = 2.0f;
		float alpha = cgroup.alpha;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			cgroup.alpha = Mathf.Lerp(alpha,0f,t);
			yield return null;
		}
		Destroy (menuPane);
	}
}
