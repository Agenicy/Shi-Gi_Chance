using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Section : MonoBehaviour
{

	[SerializeField] GameObject sec;
	public int id;
	public string type;

	private void Awake()
	{

	}

	// Use this for initialization
	void Start()
	{
		GameObject NewSec = GameObject.Instantiate(sec);//製造新區段
		NewSec.gameObject.GetComponent<SectionInfo>().info = read(id);//從資料庫中讀取區段資料並傳出
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	//////////////////

	//////////////////
	public string SecType = "HouseData";
	SecInfo read(int id)//從檔案讀取
	{
		FileStream aFile = new FileStream("Assets/Database/" + SecType + "/" + id + ".json", FileMode.Open);
		StreamReader sr = new StreamReader(aFile);
		string strLine = sr.ReadLine();
		aFile.Close();
		return JsonUtility.FromJson<SecInfo>(strLine);
	}
}
