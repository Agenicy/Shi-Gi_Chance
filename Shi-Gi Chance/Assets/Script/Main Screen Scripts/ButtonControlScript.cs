using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControlScript : MonoBehaviour {

	public GameObject MainScreen;
	//////////////////
	public Button FoodRegisterButton;
	public Button BuildButton;
	public Button AchevementButton;
	public Button StatusButton;
	//////////////////

	// Use this for initialization before awake
	void Awake()
	{
		transform.SetParent(MainScreen.transform);
	}

	// Use this for initialization
	void Start ()
	{
		FoodRegisterButton.onClick.AddListener(FoodRegisterButtonClicked);
		BuildButton.onClick.AddListener(BuildButtonClicked);
		AchevementButton.onClick.AddListener(AchevementButtonClicked);
		StatusButton.onClick.AddListener(StatusButtonClicked);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	//////////////////
	
	void FoodRegisterButtonClicked()
	{
		Debug.Log("A");
	}

	//////////////////

	void BuildButtonClicked()
	{
		Debug.Log("B");
	}

	//////////////////

	void AchevementButtonClicked()
	{
		Debug.Log("S");
	}

	//////////////////
	void StatusButtonClicked()
	{
		Debug.Log("Q");
	}
}
