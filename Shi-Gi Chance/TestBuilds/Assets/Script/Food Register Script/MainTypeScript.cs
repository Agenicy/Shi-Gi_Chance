using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTypeScript : MonoBehaviour {

	public List<string> SubType;
	public GameObject FoodTypeController;

	// Use this for initialization
	void Start () {
		FoodTypeController = GameObject.Find("FoodTypeController");
		transform.SetParent(FoodTypeController.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
