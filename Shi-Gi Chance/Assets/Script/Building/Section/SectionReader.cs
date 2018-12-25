using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SectionReader : MonoBehaviour
{
	public List<SecInfo> Reader;

	[SerializeField] GameObject sec;
	public int id;
	public string SecType = "HouseData";

	private void Awake()
	{

	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	private bool PageOpened = true;
	private int NumOfSection;
	void Update()
	{
		select();
		if (PageOpened)
		{
			PageOpened = false;
			SetReader();

		}
	}

	//////////////////

	//////////////////
	/*
	SecInfo read(int id)//從檔案讀取
	{
		FileStream aFile = new FileStream("Assets/Database/" + SecType + "/" + id + ".json", FileMode.Open);
		StreamReader sr = new StreamReader(aFile);
		string strLine = sr.ReadLine();
		Debug.Log(strLine);
		aFile.Close();
		return JsonUtility.FromJson<SecInfo>(strLine);
	}
	*/

	void SetReader()
	{
		// read in json and decode datas from it
		string json = System.IO.File.ReadAllText("Assets/Database/HouseData/" + "HouseData" + ".json");
		Reader = JsonConvert.DeserializeObject<List<SecInfo>>(json);

		////////////////////////////////

		NumOfSection = 4;

		for (int i = 0; i < NumOfSection; i++)
		{
			GameObject NewSec = GameObject.Instantiate(sec, this.transform, false);//製造新區段
			NewSec.transform.parent.SetParent(this.transform);
			NewSec.transform.localPosition += new Vector3(0, -i * NewSec.GetComponent<RectTransform>().sizeDelta.y, 0);
			NewSec.gameObject.GetComponent<SectionInfo>().info = Reader[i];//從資料庫中讀取區段資料並傳出
		}
	}

	// /////////////////////
	//滑鼠滾輪
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


	int gap = 10;
	private void mouseWheelChange(int value)
	{
		switch (value)
		{
			case -1:
				for (int i = 0; i < gap; i++)
				{
					//距離不對
					if (GetComponent<RectTransform>().localPosition.y >= -(0.5 * GetComponent<RectTransform>().sizeDelta.y - 0.5* transform.parent.GetComponent<RectTransform>().sizeDelta.y))
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
