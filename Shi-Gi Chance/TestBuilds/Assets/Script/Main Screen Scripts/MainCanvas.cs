using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour {

	//////////////////
	public GameObject MainScreen;
	//////////////////

	// Use this for initialization before awake
	void Awake ()
	{
		transform.SetParent(MainScreen.transform);
		GetComponent<RectTransform>().localPosition = Vector3.zero;
		PanelSetting();
		Screen.SetResolution(356, 632, false);
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		PanelSetting();
	}

	//////////////////

	void PanelSetting()
	{
		GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponentInParent<RectTransform>().sizeDelta.x / 3, GetComponentInParent<RectTransform>().sizeDelta.x);
	}

	//////////////////
}
