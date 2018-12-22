using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTypeControllerScript : MonoBehaviour {

	public GameObject FoodRegisterPage;
	//////////////////
	public GameObject FoodType1;
	public GameObject FoodType2;
	public GameObject FoodType3;
	public GameObject FoodType4;
	public GameObject FoodType5;
	public GameObject FoodType6;
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

	void ObjectResize()
	{
		FoodType1.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 6, 80);
		FoodType1.GetComponent<RectTransform>().localPosition = new Vector3(0, Screen.height / 2 - 120);

		FoodType2.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 6, 80);
		FoodType2.GetComponent<RectTransform>().localPosition = new Vector3(0, Screen.height / 2 - 200);

		FoodType3.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 6, 80);
		FoodType3.GetComponent<RectTransform>().localPosition = new Vector3(0, Screen.height / 2 - 280);

		FoodType4.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 6, 80);
		FoodType4.GetComponent<RectTransform>().localPosition = new Vector3(0, Screen.height / 2 - 360);

		FoodType5.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 6, 80);
		FoodType5.GetComponent<RectTransform>().localPosition = new Vector3(0, Screen.height / 2 - 440);

		FoodType6.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 6, 80);
		FoodType6.GetComponent<RectTransform>().localPosition = new Vector3(0, Screen.height / 2 - 520);
	}
}
