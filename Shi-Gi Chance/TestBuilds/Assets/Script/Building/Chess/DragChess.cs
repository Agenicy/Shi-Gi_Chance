using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChess : MonoBehaviour
{

	public bool isDrag;
	public SecInfo Info;

	private void Awake()
	{
		//預設生成時都是滑鼠按下的狀態
		isDrag = true;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
			
		}
		else
		{
			isDrag = false;
			Invoke("DeleteThis", 0.1f);
		}
	}

	/*
	void OnMouseDown()
	{

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

		isDrag = true;
	}

	void OnMouseDrag()
	{
		
		Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
		
	}
	*/
	
	void DeleteThis()
	{
		Destroy(this.gameObject);
	}
}
