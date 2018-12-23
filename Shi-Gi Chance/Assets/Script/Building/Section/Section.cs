using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Section : MonoBehaviour
{

	[SerializeField] SecInfo sec;
	public int id;
	public string type;

	private void Awake()
	{
		
	}

	// Use this for initialization
	void Start()
	{
		/*
		GameObject newCard = GameObject.Instantiate(card, new Vector3(50, -50, (float)0.1 * deckLeft.Count), Quaternion.identity);//製造新卡片模板
		newCard.gameObject.transform.GetChild(0).GetComponent<cardInfo>().info = read(id);//從資料庫中讀取卡片資料，存放至card_A
		*/
	}

	// Update is called once per frame
	void Update()
	{

	}

	//////////////////

	//////////////////
	SecInfo read(int id)//從檔案讀取
	{
		FileStream aFile = new FileStream("Assets/deck/" + id + ".json", FileMode.Open);
		StreamReader sr = new StreamReader(aFile);
		string strLine = sr.ReadLine();
		aFile.Close();
		return JsonUtility.FromJson<SecInfo>(strLine);
	}
}
