using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPageScript : MonoBehaviour {

	public GameObject[] HistoryFood;
	// Use this for initialization
	void Start () {
		SetDate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetDate()
	{
		for(int temp = 0;temp < 7;++temp)
		{
			HistoryFood[temp].GetComponentInChildren<Text>().text
			= DateTime.Today.AddDays(-(6-temp)).ToString("yyyy/MM/dd"); 
		}
	}
}
