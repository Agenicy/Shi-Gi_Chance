using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaterialMonitorScript : MonoBehaviour {

	//////////////////
	public GameObject[] BuildingMaterial = new GameObject[4];
	public GameObject MainScreenPanel;
	//////////////////

	// Use this for initialization before awake
	void Awake()
	{
		transform.SetParent(MainScreenPanel.transform);
	}

	// Use this for initialization
	void Start ()
	{
		ObjectResize();
		transform.SetAsLastSibling();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ObjectResize();
	}

	//////////////////
	
	void ObjectResize()
	{
		BuildingMaterial[0].GetComponent<RectTransform>().localPosition =
		new Vector3(10 - (Screen.width / 2) + (Screen.width - 30) / 4, Screen.height / 2 - 45, 0);
		BuildingMaterial[0].GetComponent<RectTransform>().sizeDelta =
		new Vector2((Screen.width - 30) / 2, 50);

		BuildingMaterial[1].GetComponent<RectTransform>().localPosition =
		new Vector3((Screen.width / 2) - 10 - (Screen.width - 30) / 4, Screen.height / 2 - 45, 0);
		BuildingMaterial[1].GetComponent<RectTransform>().sizeDelta =
		new Vector2((Screen.width - 30) / 2, 50);

		BuildingMaterial[2].GetComponent<RectTransform>().localPosition =
		new Vector3(10 - (Screen.width / 2) + (Screen.width - 30) / 4, Screen.height / 2 - 95, 0);
		BuildingMaterial[2].GetComponent<RectTransform>().sizeDelta =
		new Vector2((Screen.width - 30) / 2, 50);

		BuildingMaterial[3].GetComponent<RectTransform>().localPosition =
		new Vector3((Screen.width / 2) - 10 - (Screen.width - 30) / 4, Screen.height / 2 - 95, 0);
		BuildingMaterial[3].GetComponent<RectTransform>().sizeDelta =
		new Vector2((Screen.width - 30) / 2, 50);
	}
}
