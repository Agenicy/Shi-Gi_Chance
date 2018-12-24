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
	public bool HasBuilding;

	public SecInfo Info;

	// Use this for initialization
	void Start()
	{
		HasBuilding = false;
	}

	// Update is called once per frame
	void Update()
	{
		//Chess正在空地上且空地沒有建築
		if (!HasBuilding && ChessCollider && !Input.GetKey(KeyCode.Mouse0))
		{
			if (ChessCollider.gameObject.transform.GetComponent<DragChess>().isDrag == false)
			{
				BuildHouse(ChessCollider);
				GameObject.Destroy(ChessCollider.gameObject);
				SparkleOff();
			}
		}
	}

	//////////////////////

	Collider2D ChessCollider;
	void OnTriggerEnter2D(Collider2D B)
	{
		if (!HasBuilding)
		{
			ChessCollider = B;
			SparkleOff();
			InvokeRepeating("Sparkle", 0f, 0.6f);

		}
	}


	void OnTriggerExit2D(Collider2D B)
	{
		ChessCollider = null;
		CancelInvoke("Sparkle");
		SparkleOff();
	}

	//////////////////////

	//根據碰撞箱父物件生成建築，成為目前地板的子物件
	private void BuildHouse(Collider2D B)
	{
		//空地有建築了
		HasBuilding = true;

		//將透明度改回去
		SparkleOff();

		//從棋子Info取得所有建築物資訊
		Info = B.gameObject.transform.GetComponent<DragChess>().Info;

		//製造建築模板
		CreateBuildingTemplate();
	}


	//棋子停留時閃爍
	private void Sparkle()
	{
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 0.5f);

		Invoke("SparkleOff", 0.3f);
	}

	private void SparkleOff()
	{
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 1f);
	}

	//製造建築模板
	void CreateBuildingTemplate()
	{
		GameObject building = GameObject.Instantiate(BuildingTemplate, transform, false);
		building.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Info.Icon);
	}
}
