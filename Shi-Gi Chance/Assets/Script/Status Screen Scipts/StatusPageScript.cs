using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StatusPageScript : MonoBehaviour {

	public GameObject[] HistoryFood;
	public string[] help;

	void Awake()
	{
		ReadData();
	}
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

	public void SaveData()
	{
		StreamWriter FoodSaver = new StreamWriter("Assets/Resources/Save/FoodHistory.txt", false);
		for (int temp = 0; temp < 7; ++temp)
		{
			foreach (Dropdown.OptionData FoodName in HistoryFood[temp].GetComponentInChildren<Dropdown>().options)
			{
				FoodSaver.WriteLine(FoodName.text + " ");
			}
			FoodSaver.WriteLine("\r\n");
		}
		FoodSaver.Close();
	}

	public void ReadData()
	{
		int ReadedLine = 0;
		help = File.ReadAllLines("Assets/Resources/Save/FoodHistory.txt");
		for(int temp3 = 0; temp3 < 7; ++temp3)
		{
			for (int temp2 = ReadedLine; temp2 < help.Length; ++temp2)
			{
				if (help[temp2] != "")
				{
					HistoryFood[temp3].GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData(help[temp2]));
				}
				else
				{
					ReadedLine = ++temp2;
					++ReadedLine;
					break;
				}
			}
		}
	}
}

public class HistoryFoodData
{
	public DateTime date;
	public List<string> foods;
}

