using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	[SerializeField] GameObject PauseCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseBtn()
	{
		PauseCanvas.SetActive(true);
	}

	public void PlayBtn()
	{
		PauseCanvas.SetActive(false);
	}
}
