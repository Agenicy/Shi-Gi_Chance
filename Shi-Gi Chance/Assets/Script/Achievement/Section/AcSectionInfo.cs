using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SecInfo
{
	public int ID;
	public string Title;
	public string Document;
	public string Icon;
	public string Type;
	public int Coin;
	public int Wood;
	public int Metal;
	public int Concrete;
	public string BuildOn;
}

public class AcSectionInfo : MonoBehaviour, IPointerDownHandler
{

	public SecInfo info;

	public bool Available;
	// Use this for initialization
	void Start()
	{
		isAvailable();
		display();
	}

	// Update is called once per frame
	void Update()
	{

	}


	////////////////

	[SerializeField] GameObject ChessTemplate;
	//內容被按壓時執行
	public void OnPointerDown(PointerEventData eventData)
	{
		if (Available)
		{
			/*如果可以執行的話要做的動作*/

			//關閉本頁面
			//ClosePage();
		}
		else
		{
			//Do nothing
		}

	}

	////////////////

	//檢查是否可用
	private void isAvailable()
	{
		//替換成你的
		/*
		GameObject BuildMaterialMonitor = GameObject.Find("BuildMaterialMonitor");
		if (info.Coin > BuildMaterialMonitor.GetComponent<MaterialManage>().MaterialQuery("Coin") || info.Wood > BuildMaterialMonitor.GetComponent<MaterialManage>().MaterialQuery("Wood") || info.Metal > BuildMaterialMonitor.GetComponent<MaterialManage>().MaterialQuery("Metal") || info.Concrete > BuildMaterialMonitor.GetComponent<MaterialManage>().MaterialQuery("Concrete"))
		{
			Available = false;
		}
		else
		{
			Available = true;
		}
		*/
	}

	//根據JSON更改內容
	private void display()
	{
		/*改成你的東西*/
		transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(info.Icon);//圖示
		transform.GetChild(1).GetChild(1).gameObject.GetComponent<Text>().text = info.Title;//標題
		transform.GetChild(1).GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = info.Document;//內容

		if (!Available)//如果不行，更改背景顏色
		{
			transform.GetChild(1).GetComponent<RawImage>().color = new Color32(150, 100, 100, 255);
		}
	}

	private GameObject ButtonControl;
	//關閉所有頁面
	private void ClosePage()
	{
		/*BuildButtonClicked你要再自己建*/

		//搜尋Editor中的物件
		ButtonControl = GameObject.Find("ButtonControl");

		//點擊建築按鈕，關閉頁面
		if (ButtonControl.GetComponent<ButtonControlScript>().BuildPageIsShowing)
		{
			ButtonControl.GetComponent<ButtonControlScript>().BuildButtonClicked();

			//重設頁面
			transform.parent.GetComponent<SectionReader>().PageOpened = true;
		}
	}

	// ////////////
	public void Hover()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		GetComponent<AudioSource>().Play();
	}

	public void NoHover()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}
}
