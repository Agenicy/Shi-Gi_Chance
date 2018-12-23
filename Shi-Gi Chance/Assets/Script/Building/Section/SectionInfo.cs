using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecInfo
{
	public int ID;
	public string Title;
	public string Document;
	public string Icon;
	public string Type;
}

public class SectionInfo : MonoBehaviour
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

	private void display()
	{
		transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(info.Icon);
		transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = info.Title;
		transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = info.Document;
	}
}
