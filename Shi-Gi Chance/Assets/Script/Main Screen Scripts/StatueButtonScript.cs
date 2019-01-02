using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueButtonScript : MonoBehaviour {

	//////////////////
	public GameObject MainScreenPanel;
	//////////////////

	// Use this for initialization before Start()
	void Awake ()
	{
		//transform.SetParent(MainScreenPanel.transform);
	}
	
	// Use this for initialization
	void Start ()
	{
		//ObjectResize();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//ObjectResize();
	}

	//////////////////
	void ObjectResize()
	{
		GetComponent<RectTransform>().sizeDelta = new Vector2((Screen.width - 100) / 4, (Screen.width - 100) / 4);
		transform.localPosition = new Vector3(20 - (Screen.width / 2) + (Screen.width - 100) / 8, 20 + (Screen.width - 100) / 4 - (Screen.height / 2) - (Screen.width - 100) / 8, 5);
		transform.SetAsLastSibling();
	}
}
