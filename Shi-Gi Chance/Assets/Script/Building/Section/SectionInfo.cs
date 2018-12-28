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

public class SectionInfo : MonoBehaviour, IPointerDownHandler
{

	public SecInfo info;
	// Use this for initialization
	void Start()
	{
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
		//生成棋子
		GameObject buildingChess = GameObject.Instantiate(ChessTemplate, transform.position, Quaternion.identity);

		//修改棋子圖案
		SetChess(buildingChess);

		//將棋子移動到滑鼠上
		Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		buildingChess.transform.position = Camera.main.ScreenToWorldPoint(newPosition);

		//關閉頁面
		ClosePage();
	}

	////////////////


	//根據JSON更改內容
	private void display()
	{
		transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(info.Icon);//圖示
		transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = info.Title;//標題
		transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = info.Document;//內容
	}

	private GameObject ButtonControl;
	//關閉所有頁面
	private void ClosePage()
	{
		//搜尋Editor中的物件
		ButtonControl = GameObject.Find("ButtonControl");

		//點擊建築按鈕，關閉頁面
		if (ButtonControl.GetComponent<ButtonControlScript>().BuildPageIsShowing)
		{
			ButtonControl.GetComponent<ButtonControlScript>().BuildButtonClicked();
		}
	}

	//修改棋子圖案 & ID
	void SetChess(GameObject Chess)
	{
		Chess.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(info.Icon);
		Chess.GetComponent<DragChess>().Info = info;
	}

}
