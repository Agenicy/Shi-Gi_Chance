using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControlScript : MonoBehaviour
{

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
	void Start()
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
	void Update()
	{

	}

	//////////////////
	public void CloseAllPagesWithout(int x)
	{
		if (FoodRegisterPageIsShowing && x != 0)
		{
			FoodRegisterButtonClicked();
		}
		if (BuildPageIsShowing && x != 1)
		{
			BuildButtonClicked();
		}
		if (AchevementPageIsShowing && x != 2)
		{
			AchevementButtonClicked();
		}
		if (StatusPageIsShowing && x != 3)
		{
			StatusButtonClicked();
		}
	}

	public GameObject FoodRegisterPage;
	public GameObject FoodTypeController;
	private bool FoodRegisterPageIsShowing;

	void FoodRegisterButtonClicked()
	{
		CloseAllPagesWithout(0);

		Debug.Log("A");
		FoodRegisterPageIsShowing = !FoodRegisterPageIsShowing;
		FoodRegisterPage.SetActive(FoodRegisterPageIsShowing);
		FoodTypeController.GetComponent<FoodTypeControllerScript>().UnselectAllMaintype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().UnselectAllSubtype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().ShowAllMaintype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().HideAllSubtype();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().CreateFoodList();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().HideDropdown();
		FoodTypeController.GetComponent<FoodTypeControllerScript>().ClearDropdown();
	}

	//////////////////
	public GameObject BuildPage;
	public bool BuildPageIsShowing;
	public void BuildButtonClicked()
	{
		CloseAllPagesWithout(1);

		Debug.Log("B");
		BuildPageIsShowing = !BuildPageIsShowing;
		BuildPage.SetActive(BuildPageIsShowing);
	}

	//////////////////
	public GameObject AchevementPage;
	public GameObject AchScrollingField;
	private bool AchevementPageIsShowing;
	void AchevementButtonClicked()
	{
		CloseAllPagesWithout(2);

		Debug.Log("S");
		AchevementPageIsShowing = !AchevementPageIsShowing;
		AchevementPage.SetActive(AchevementPageIsShowing);
		if (AchevementPageIsShowing)
			AchScrollingField.GetComponent<AchScrollingFieldScript>().DisplayBlocks();
		if (!AchevementPageIsShowing)
		{
			for (int temp = AchScrollingField.GetComponent<AchScrollingFieldScript>().QuestBlockList.Count - 1; temp >= 0; --temp)
			{
				Destroy(AchScrollingField.GetComponent<AchScrollingFieldScript>().QuestBlockList[temp]);
				AchScrollingField.GetComponent<AchScrollingFieldScript>().QuestBlockList.Clear();
			}
		}
	}

	//////////////////
	public GameObject StatusPage;
	public GameObject StatusPageController;
	private bool StatusPageIsShowing;
	void StatusButtonClicked()
	{
		CloseAllPagesWithout(3);

		Debug.Log("Q");
		StatusPageIsShowing = !StatusPageIsShowing;
		StatusPage.SetActive(StatusPageIsShowing);
		if (StatusPageIsShowing)
			StatusPageController.GetComponent<StatusPageScript>().ReadData();
		if (!StatusPageIsShowing)
			StatusPageController.GetComponent<StatusPageScript>().SaveData();
	}
}
