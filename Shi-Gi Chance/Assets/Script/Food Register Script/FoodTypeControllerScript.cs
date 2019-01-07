using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class FoodTypeControllerScript : MonoBehaviour {

	public GameObject FoodRegisterPage;
	public GameObject FoodChoosingDropdown;
	public GameObject ConfirmButton;
	public GameObject HistoryFood;
	//////////////////
	public GameObject[] Maintype;
	public GameObject[] Subtype;
	public List<Food> SelectedFood;
	public string JSONString;
	//////////////////

	// Use this for initialization before start
	void Awake()
	{
		transform.SetParent(FoodRegisterPage.transform);
		ConfirmButton.GetComponent<Button>().onClick.AddListener(ConfirmButtonClicked);
		CreateFoodList();
	}

	// Use this for initialization
	void Start ()
	{
		ShowAllMaintype();
		HideAllSubtype();
		UnselectAllMaintype();
		HideDropdown();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DetectMaintypeToggle();
		DetectSubtypeToggle();
	}

	//////////////////

	public void DetectMaintypeToggle()
	{
		for(int temp = 0;temp < 16;++temp)
		{
			if(Maintype[temp].GetComponent<Toggle>().isOn)
			{
				GameObject TempMainType = Maintype[temp];
				HideAllMaintype();
				for(int temp2 = 0;temp2 < TempMainType.GetComponent<MainTypeScript>().SubType.Count;++temp2)
				{
					Subtype[temp2].SetActive(true);
					Subtype[temp2].GetComponentInChildren<Text>().text = TempMainType.GetComponent<MainTypeScript>().SubType[temp2];
				}
				Maintype[temp].GetComponent<Toggle>().isOn = false;
				for (int temp2 = SelectedFood.Count - 1; temp2 >= 0; --temp2)
				{
					if (SelectedFood[temp2].MainType != temp + 1)
					{
						SelectedFood.RemoveAt(temp2);
					}
				}
				break;
			}
		}
	}

	public void DetectSubtypeToggle()
	{
		for(int temp = 0;temp < 10;++temp)
		{
			if(Subtype[temp].GetComponent<Toggle>().isOn)
			{
				//GameObject TempSubType = Subtype[temp];
				HideAllSubtype();
				for (int temp2 = SelectedFood.Count - 1; temp2 >= 0; --temp2)
				{
					if (SelectedFood[temp2].SubType != temp + 1)
					{
						SelectedFood.RemoveAt(temp2);
					}
				}
				foreach (Food food in SelectedFood)
				{
					FoodChoosingDropdown.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(food.FoodName));
				}
				UnselectAllSubtype();
				ShowDropdown();
				break;
			}

		}
	}

	public void UnselectAllMaintype()
	{
		for (int temp = 0; temp < 16; ++temp)
		{
			Maintype[temp].GetComponent<Toggle>().isOn = false;
		}
	}

	public void UnselectAllSubtype()
	{
		for (int temp = 0; temp < 10; ++temp)
		{
			Subtype[temp].GetComponent<Toggle>().isOn = false;
		}
	}

	public void HideAllMaintype()
	{
		for(int temp = 0;temp < 16;++temp)
		{
			Maintype[temp].SetActive(false);
		}
	}

	public void ShowAllMaintype()
	{
		for (int temp = 0; temp < 16; ++temp)
		{
			Maintype[temp].SetActive(true);
		}
	}

	public void HideAllSubtype()
	{
		for (int temp = 0; temp < 10; ++temp)
		{
			Subtype[temp].SetActive(false);
		}
	}

	public void HideDropdown()
	{
		FoodChoosingDropdown.SetActive(false);
		ConfirmButton.SetActive(true);
	}

	public void ShowDropdown()
	{
		FoodChoosingDropdown.SetActive(true);
		FoodChoosingDropdown.GetComponentInChildren<Text>().text
		= FoodChoosingDropdown.GetComponent<Dropdown>().options[FoodChoosingDropdown.GetComponent<Dropdown>().value].text;
		ConfirmButton.SetActive(true);
	}

	public void ClearDropdown()
	{
		int temp = FoodChoosingDropdown.GetComponent<Dropdown>().options.Count - 1;
		for(;temp >= 0;--temp)
		{
			FoodChoosingDropdown.GetComponent<Dropdown>().options.RemoveAt(temp);
		}
	}

	public void CreateFoodList()
	{
		JSONString = File.ReadAllText("Assets/Database/Food.json");
		SelectedFood = JsonConvert.DeserializeObject<List<Food>>(JSONString);
		//Debug.Log(JsonConvert.DeserializeObject<List<Food>>(JSONString)[12].FoodName);
	}

	public void ConfirmButtonClicked()
	{
		HistoryFood.GetComponent<StatusPageScript>().TodaysFood.Add(FoodChoosingDropdown.GetComponent<Dropdown>().options[FoodChoosingDropdown.GetComponent<Dropdown>().value].text);
	}
}

[System.Serializable]
public class Food
{
	public string FoodName;
	public int MainType;
	public int SubType;
}
