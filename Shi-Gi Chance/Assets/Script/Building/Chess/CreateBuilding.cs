using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Building
{
	public int ID;
	public string Icon;
}

public class CreateBuilding : MonoBehaviour
{

	public GameObject BuildingTemplate;
	public string BuildingName;

	public SecInfo Info;

	// Use this for initialization
	void Start()
	{
		BuildingName = "空地";
	}

	// Update is called once per frame
	void Update()
	{
		//Chess正在可以建築的位置上
		if (ChessCollider && BuildingName == ChessCollider.gameObject.GetComponent<DragChess>().Info.BuildOn && !Input.GetKey(KeyCode.Mouse0))
		{
			if (ChessCollider.gameObject.transform.GetComponent<DragChess>().isDrag == false)//滑鼠放開
			{
				BuildHouse(ChessCollider);//建築房屋
				GameObject.Destroy(ChessCollider.gameObject);//刪除棋子
				SparkleOff();//結束閃爍特效
			}
		}
	}

	//////////////////////

	Collider2D ChessCollider;
	void OnTriggerEnter2D(Collider2D B)
	{
		if (BuildingName == B.gameObject.GetComponent<DragChess>().Info.BuildOn)//可以建築的地點
		{
			ChessCollider = B;//取得棋子碰撞箱
			SparkleOff();//結束閃爍(重設閃爍特效)
			InvokeRepeating("Sparkle", 0f, 0.6f);//開始閃爍特效
		}
	}


	void OnTriggerExit2D(Collider2D B)
	{
		ChessCollider = null;//刪除棋子紀錄 = 棋子離開
		CancelInvoke("Sparkle");//取消重複閃爍
		SparkleOff();//停止閃爍
	}

	//////////////////////

	//根據碰撞箱父物件生成建築，成為目前地板的子物件
	private void BuildHouse(Collider2D B)
	{

		//將透明度改回去
		SparkleOff();

		//從棋子Info取得所有建築物資訊
		Info = B.gameObject.transform.GetComponent<DragChess>().Info;

		//更改建築名稱
		BuildingName = Info.Title;

		//製造建築模板
		CreateBuildingTemplate();
	}


	//棋子停留時閃爍
	private void Sparkle()
	{
		//更改凸面透明度
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 0.5f);

		//過一段時間後呼叫SparkleOff函式，改回透明度
		Invoke("SparkleOff", 0.3f);
	}

	//結束閃爍
	private void SparkleOff()
	{
		//改回透明度
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 1f);
	}

	//製造建築模板
	GameObject building;
	void CreateBuildingTemplate()
	{
		//刪除建築模板(若有)
		DeleteBuildingTemplate();

		//生成房屋代表物
		building = GameObject.Instantiate(BuildingTemplate, transform, false);
		
		//更改圖案
		building.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Info.Icon);
	}

	//刪除建築模板
	private void DeleteBuildingTemplate()
	{
		if (building)
		{
			Destroy(building);
		}
	}
}
