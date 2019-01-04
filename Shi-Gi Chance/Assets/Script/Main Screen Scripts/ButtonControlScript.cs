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

		FoodRegisterPageIsShowing = false;
		FoodRegisterPage.SetActive(FoodRegisterPageIsShowing);

		BuildPageIsShowing = false;
		BuildPage.SetActive(BuildPageIsShowing);

		AchevementPageIsShowing = false;
		AchevementPage.SetActive(AchevementPageIsShowing);

		StatusPageIsShowing = false;
		StatusPage.SetActive(StatusPageIsShowing);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	//////////////////
	public GameObject FoodRegisterPage;
	public GameObject FoodTypeController;
	private bool FoodRegisterPageIsShowing;
	
	void FoodRegisterButtonClicked()
	{
		Debug.Log("A");
		FoodRegisterPageIsShowing = !FoodRegisterPageIsShowing;
		FoodRegisterPage.SetActive(FoodRegisterPageIsShowing);
		FoodTypeController.GetComponent<FoodTypeControllerScript>().UnselectAllMaintype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().UnselectAllSubtype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().ShowAllMaintype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().HideAllSubtype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().CreateFoodList();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().HideDropdown();
	}

	//////////////////
	public GameObject BuildPage;
	public bool BuildPageIsShowing;
	public void BuildButtonClicked()
	{
		Debug.Log("B");
		BuildPageIsShowing = !BuildPageIsShowing;
		BuildPage.SetActive(BuildPageIsShowing);
	}

	//////////////////
	public GameObject AchevementPage;
	private bool AchevementPageIsShowing;
	void AchevementButtonClicked()
	{
		Debug.Log("S");
		AchevementPageIsShowing = !AchevementPageIsShowing;
		AchevementPage.SetActive(AchevementPageIsShowing);
	}

	//////////////////
	public GameObject StatusPage;
	public GameObject StatusPageController;
	private bool StatusPageIsShowing;
	void StatusButtonClicked()
	{
		Debug.Log("Q");
		StatusPageIsShowing = !StatusPageIsShowing;
		StatusPage.SetActive(StatusPageIsShowing);
		StatusPageController.GetComponent<StatusPageScript>().SaveData();
	}
}
