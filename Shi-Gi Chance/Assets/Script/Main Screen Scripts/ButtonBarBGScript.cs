using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBarBGScript : MonoBehaviour {

	//////////////////
	public GameObject MainScreen;
	//////////////////

	// Use this for initialization before awake
	void Awake()
	{
		transform.SetParent(MainScreen.transform);
	}
	// Use this for initialization
	void Start ()
	{
		// ObjectResize();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// ObjectResize();
	}

	//////////////////
	void ObjectResize()
	{
		GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, (Screen.width - 100) / 2.45f);
		GetComponent<RectTransform>().localPosition = new Vector3(0, -(Screen.height / 2) + GetComponent<RectTransform>().sizeDelta.y / 2, 0);
	}
}
