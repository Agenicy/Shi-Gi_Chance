﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRegisterBGScript : MonoBehaviour {

	public GameObject FoodRegisterPage;
	//////////////////

	//////////////////

	// Use this for initialization before start
	void Awake()
	{
		transform.SetParent(FoodRegisterPage.transform);
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
	
	void ObjectResize ()
	{
		//GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height - 160 - Screen.width / 4);
		//GetComponent<RectTransform>().localPosition = Vector3.zero;
	}
}
