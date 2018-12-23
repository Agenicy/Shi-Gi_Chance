using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SectionReader : MonoBehaviour
{

	[SerializeField] GameObject sec;
	public int id;
	public string SecType = "HouseData";

	private void Awake()
	{

	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	private bool PageOpened = true;
	void Update()
	{
		if (PageOpened)
		{
			PageOpened = false;
			GameObject NewSec = GameObject.Instantiate(sec,transform,false);//製造新區段
			NewSec.transform.parent = this.transform;
			NewSec.gameObject.GetComponent<SectionInfo>().info = read(id);//從資料庫中讀取區段資料並傳出
		}

	}

	//////////////////

	//////////////////
	SecInfo read(int id)//從檔案讀取
	{
		FileStream aFile = new FileStream("Assets/Database/" + SecType + "/" + id + ".json", FileMode.Open);
		StreamReader sr = new StreamReader(aFile);
		string strLine = sr.ReadLine();
		Debug.Log(strLine);
		aFile.Close();
		return JsonUtility.FromJson<SecInfo>(strLine);
	}
}
