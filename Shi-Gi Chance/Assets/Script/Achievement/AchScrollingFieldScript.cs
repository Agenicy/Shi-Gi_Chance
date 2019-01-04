using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchScrollingFieldScript : MonoBehaviour {

	public List<GameObject> QuestBlockList;
	[SerializeField] private int[] QuestStatus;
	
	void Awake()
	{
		Debug.Log(File.ReadAllText("Assets/Resources/Save/QuestStatus.txt").Length);
		StringReader QuestStatusReader = new StringReader(File.ReadAllText("Assets/Resources/Save/QuestStatus.txt"));
		char[] temp = new char[File.ReadAllText("Assets/Resources/Save/QuestStatus.txt").Length];
		QuestStatusReader.Read(temp, 0, temp.Length);
		QuestStatus = new int[temp.Length];
		for(int temp2 = 0;temp2 < QuestStatus.Length;++temp2)
		{
			QuestStatus[temp2] = temp[temp2] - '0';
		}
		Debug.Log("Size of int array is " + QuestStatus.Length);
		Debug.Log("Size of char array is " + temp.Length);
	}

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		MouseWheelScroll();
	}

	public GameObject QuestBlock;
	public void CreateBlock()
	{
		GameObject NewBlock = Instantiate(QuestBlock, transform, true);
		QuestBlockList.Add(NewBlock);
	}

	public void DisplayBlocks()
	{
		Quest1();

		for (int temp = QuestBlockList.Count - 1;temp >= 0;--temp)
		{
			QuestBlockList[temp].transform.localPosition = new Vector3(0, 250 - (310 * temp), 0);
			QuestBlockList[temp].transform.localScale = Vector3.one;
		}

		StreamWriter QuestStatusUpdater = new StreamWriter("Assets/Resources/Save/QuestStatus.txt", false);
		foreach (int Status in QuestStatus)
		{
			QuestStatusUpdater.Write(Status.ToString());
		}
		QuestStatusUpdater.Close();
	}

	private void MouseWheelScroll()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			if (QuestBlockList[QuestBlockList.Count - 1].transform.localPosition.y <= 250)
				foreach (GameObject Block in QuestBlockList)
				{
					Block.transform.localPosition += new Vector3(0, 30, 0);
				}
			else
				QuestBlockList[QuestBlockList.Count - 1].transform.localPosition = new Vector3(0, 250);
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (QuestBlockList[0].transform.localPosition.y >= -250)
				foreach (GameObject Block in QuestBlockList)
				{
					Block.transform.localPosition -= new Vector3(0, 30, 0);
				}
			else
				QuestBlockList[0].transform.localPosition = new Vector3(0, -250, 0);
		}
	}

	private void QuestBase(string QuestTitle, string QuestDescription, bool Cleared)
	{
		if (!Cleared)
		{
			CreateBlock();
			foreach (Text TextObject in QuestBlockList[QuestBlockList.Count - 1].GetComponentsInChildren<Text>())
			{
				if (TextObject.name == "Quest Title")
					TextObject.text = QuestTitle;
				else if(TextObject.name == "Quest Description")
					TextObject.text = QuestDescription;
			}
		}
	}

	private void QuestClear(int QuestNO)
	{
		QuestStatus[QuestNO - 1] = 2;
	}

	public GameObject FoodHistory;
	public GameObject BuildMaterialMonitor;
	private void Quest1()
	{
		QuestBase("有種不要過", "喝水", QuestStatus[1 - 1] == 2);
		bool Cleared = false;
		for(int temp = 0;temp < FoodHistory.GetComponent<StatusPageScript>().help.Length;++temp)
		{
			if (FoodHistory.GetComponent<StatusPageScript>().help[temp] == "水")
			{
				Cleared = true;
				break;
			}
		}
		if (Cleared)
			QuestStatus[1 - 1] = 1;
		if (QuestStatus[1 - 1] == 1)
			QuestBlockList[QuestBlockList.Count - 1].GetComponentInChildren<Button>().interactable = true;
		else
			QuestBlockList[QuestBlockList.Count - 1].GetComponentInChildren<Button>().interactable = false;
		QuestBlockList[QuestBlockList.Count - 1].GetComponentInChildren<Button>().onClick.AddListener(() => { BuildMaterialMonitor.GetComponent<MaterialManage>().AddMaterial(100, 100, 100, 100); QuestClear(1); });
	}
}
