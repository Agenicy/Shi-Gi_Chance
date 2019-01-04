using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class AcSectionReader : MonoBehaviour
{
	public List<AchInfo> AcReader;

	[SerializeField] GameObject sec;
	[SerializeField] GameObject top;
	public int id;
	public string SecType = "HouseData";
	int Page;

	private void Awake()
	{

	}

	// Use this for initialization
	void Start()
	{
		Page = 0;
	}

	// Update is called once per frame
	public bool PageOpened = true;
	private int NumOfSection;
	void Update()
	{
		select();//滑鼠滾輪

		if (PageOpened)//只在打開時執行一次
		{
			PageOpened = false;
			SetReader(Page);
			ScrollToTop();
		}
	}

	//////////////////

	//////////////////

	//讀取(Json)Section內容
	public void SetReader(int page)//page = 0/1/2
	{
		Page = page;//讓外部可以更改Page的值

		//delete all section
		ClearReader();

		/*改成 成就資料庫*/
		// read in json and decode data from it
		string json = System.IO.File.ReadAllText("Assets/Database/HouseData/" + "HouseData" + ".json");
		AcReader = JsonConvert.DeserializeObject<List<AchInfo>>(json);

		////////////////////////////////
		/*
		NumOfSection = 10;
		//生成Section
		for (int i = 0; i < NumOfSection; i++)
		{
			if (Reader[i+10 * Page].Title == "NULL")
			{
				GameObject topBtn = GameObject.Instantiate(top, this.transform, false);
				topBtn.transform.parent.SetParent(this.transform);
				topBtn.transform.localPosition += new Vector3(0, -i * sec.GetComponent<RectTransform>().sizeDelta.y- topBtn.GetComponent<RectTransform>().sizeDelta.y, 0);

				break;
			}

			GameObject NewSec = GameObject.Instantiate(sec, this.transform, false);
			NewSec.transform.parent.SetParent(this.transform);
			NewSec.transform.localPosition += new Vector3(0, -i * NewSec.GetComponent<RectTransform>().sizeDelta.y, 0);
			NewSec.gameObject.GetComponent<SectionInfo>().info = Reader[i + 10 * Page];//從資料庫中讀取區段資料並傳出
		}
		*/
	}

	//清空Reader
	public void ClearReader()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}

	// /////////////////////
	//滑鼠滾輪part1
	private void select()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			mouseWheelChange(1);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			mouseWheelChange(-1);
		}
	}

	int gap = 30;
	//滑鼠滾輪part2
	private void mouseWheelChange(int value)
	{
		switch (value)
		{
			case -1:
				for (int i = 0; i < gap; i++)
				{
					//距離不對
					if (GetComponent<RectTransform>().localPosition.y >= -(0.5 * GetComponent<RectTransform>().sizeDelta.y - 0.5 * transform.parent.GetComponent<RectTransform>().sizeDelta.y))
					{
						GetComponent<RectTransform>().localPosition += new Vector3(0, -1, 0);
					}
					else
					{
						break;
					}
				}

				break;
			case 1:
				for (int i = 0; i < gap; i++)
				{
					if (GetComponent<RectTransform>().localPosition.y <= 0.5 * (GetComponent<RectTransform>().sizeDelta.y - transform.parent.GetComponent<RectTransform>().sizeDelta.y))
					{
						GetComponent<RectTransform>().localPosition += new Vector3(0, 1, 0);
					}
					else
					{
						break;
					}
				}
				break;
		}
	}

	//Top捲動按鈕
	public void ScrollToTop()
	{
		GetComponent<RectTransform>().localPosition = new Vector3(0, (float)-(0.5 * GetComponent<RectTransform>().sizeDelta.y - 0.5 * transform.parent.GetComponent<RectTransform>().sizeDelta.y), 0);
	}

}
