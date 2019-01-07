using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRegisterPageScript : MonoBehaviour {

	//////////////////
	public GameObject MainUI;
	//////////////////

	// Use this for initialization before awake
	void Awake()
	{
		transform.SetParent(MainUI.transform);
		
	}

	// Use this for initialization
	void Start ()
	{
		ObjectResize();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ObjectResize();
	}

	//////////////////
	
	void ObjectResize()
	{
		GetComponent<RectTransform>().sizeDelta = GetComponentInParent<RectTransform>().sizeDelta;
		GetComponent<RectTransform>().localPosition = Vector3.zero;
	}
}
