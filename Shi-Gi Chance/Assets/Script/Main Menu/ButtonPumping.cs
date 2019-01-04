using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPumping : MonoBehaviour {

	[SerializeField] AudioClip Hover;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PumpIn()
	{
		transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.05f, 1.05f, 1);

		GetComponent<AudioSource>().clip = Hover;
		GetComponent<AudioSource>().Play();
	}

	public void PumpOut()
	{
		transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
	}
}
