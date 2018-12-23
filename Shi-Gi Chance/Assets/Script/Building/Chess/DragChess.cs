using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChess : MonoBehaviour {

	private Vector3 offset;
	//private float MousePower=10;
	public bool isDrag;

	void OnMouseDown()
	{

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

		//滑鼠放開瞬間開啟旋轉鎖定
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

		isDrag = true;
	}

	void OnMouseDrag()
	{
		Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;

	}

	void OnMouseUp()
	{
		isDrag = false;
	}
}
