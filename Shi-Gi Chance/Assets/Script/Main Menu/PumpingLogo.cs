
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpingLogo : MonoBehaviour
{
	[SerializeField] float BPM;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("Bumping",0, 2*(float)60 / BPM);
		GetComponent<AudioSource>().Play();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void Bumping()
	{
		transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.05f, 1.05f, 1);
		Invoke("BumpingOver", (float)60 / BPM);
	}

	private void BumpingOver()
	{
		transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
	}
}
