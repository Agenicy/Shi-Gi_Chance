using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
	public int ID;
	public string BuildingName;
}

public class CreateBuilding : MonoBehaviour {

	public GameObject BuildingTemplate;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	//////////////////////
	
	void OnTriggerEnter2D(Collider2D B)
	{
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 1f);
	}

	void OnTriggerStay2D(Collider2D B)
	{
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 0.5f);

		if (B.gameObject.transform.GetComponent<DragChess>().isDrag == false)
		{
			BuildHouse(B);
			GameObject.Destroy(B.gameObject);
			this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 1f);
		}
	}

	void OnTriggerExit2D(Collider2D B)
	{
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.transform.GetComponent<SpriteRenderer>().color.r, this.gameObject.transform.GetComponent<SpriteRenderer>().color.g, this.gameObject.transform.GetComponent<SpriteRenderer>().color.b, 1f);
	}

	//////////////////////
	//根據碰撞箱父物件生成建築，成為目前地板的子物件
	private void BuildHouse(Collider2D B)
	{
		//將透明度改回去

		//製造建築模板
		GameObject building = GameObject.Instantiate(BuildingTemplate, transform, false);

		//從棋子ID取得所有建築物資訊
		/***/

	}
}
