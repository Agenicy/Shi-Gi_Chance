using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StatusPageScript : MonoBehaviour {

	public GameObject[] HistoryFood;
	public List<string> TodaysFood;

	void Awake()
	{

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
			= DateTime.Today.AddDays(-(6-temp)).ToString("yyyy-MM-dd"); 
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
		FoodSaver.WriteLine(DateTime.Today.ToString("yyyy-MM-dd"));
		FoodSaver.Close();
	}

	public string[] help;
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

		Debug.Log(help[help.Length - 1]);
		Debug.Log(DateTime.Today.ToString("yyyy-MM-dd"));
		Debug.Log(DateTime.ParseExact(help[help.Length - 1], "yyyy-MM-dd", null).ToString("yyyy-MM-dd"));
		if(help[help.Length - 1] != DateTime.Today.ToString("yyyy-MM-dd"))
		{ 
			int DayToMove = 1;
			Debug.Log(DateTime.ParseExact(help[help.Length - 1], "yyyy-MM-dd", null).AddDays(DayToMove).ToString("yyyy-MM-dd"));
			while(DateTime.ParseExact(help[help.Length - 1], "yyyy-MM-dd", null).AddDays(DayToMove).ToString("yyyy-MM-dd")
			!= DateTime.Today.ToString("yyyy-MM-dd"))
			{
				++DayToMove;
				Debug.Log("Day to move = " + DayToMove.ToString());
			}

			for(int temp2 = 0;temp2 < 7 - DayToMove;++temp2)
			{
				for(int temp3 = HistoryFood[temp2].GetComponentInChildren<Dropdown>().options.Count - 1;temp3 >= 0;--temp3)
				{
					HistoryFood[temp2].GetComponentInChildren<Dropdown>().options.RemoveAt(temp3);
				}
				foreach(Dropdown.OptionData FoodName in HistoryFood[temp2 + DayToMove].GetComponentInChildren<Dropdown>().options)
				{
					HistoryFood[temp2].GetComponentInChildren<Dropdown>().options.Add
					(new Dropdown.OptionData(FoodName.text));
				}
			}

			for(int temp2 = 7 - DayToMove;temp2 < 7;++temp2)
			{
				for (int temp3 = HistoryFood[temp2].GetComponentInChildren<Dropdown>().options.Count - 1; temp3 >= 0; --temp3)
					HistoryFood[temp2].GetComponentInChildren<Dropdown>().options.RemoveAt(temp3);
			}
		}
		foreach (string FoodName in TodaysFood)
		{
			HistoryFood[6].GetComponentInChildren<Dropdown>().options.Add(new Dropdown.OptionData(FoodName));
		}
		for(int temp2 = TodaysFood.Count - 1;temp2 >= 0;--temp2)
		{
			TodaysFood.RemoveAt(temp2);
		}
	}
}

public class HistoryFoodData
{
	public DateTime date;
	public List<string> foods;
}

