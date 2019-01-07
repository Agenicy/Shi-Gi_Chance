using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveFile
{
	public int Coin { get; set; }
	public int Wood { get; set; }
	public int Metal { get; set; }
	public int Concrete { get; set; }
}

public class MaterialManage : MonoBehaviour
{
	SaveFile saveFile;
	string FilePath = "Assets/Save/SaveFile.json";
	
	int Coin, Wood, Metal, Concrete;

	private void Awake()
	{
		// read in json and decode data from it
		string json = File.ReadAllText(FilePath);
		saveFile = JsonConvert.DeserializeObject<SaveFile>(json);
	}

	// Use this for initialization
	void Start()
	{
		//讀取存檔
		Coin = saveFile.Coin;
		Wood = saveFile.Wood;
		Metal = saveFile.Metal;
		Concrete = saveFile.Concrete;

		Refresh();
	}

	// Update is called once per frame
	void Update()
	{

	}

	// ///////////

	// //////////
	int MaterialLimit = 999999;
	//增加數量
	public void AddMaterial(int Coin, int Wood, int Metal, int Concrete)
	{
		this.Coin = Coin + this.Coin > MaterialLimit ? MaterialLimit : Coin + this.Coin;
		this.Wood = Wood + this.Wood > MaterialLimit ? MaterialLimit : Wood + this.Wood;
		this.Metal = Metal + this.Metal > MaterialLimit ? MaterialLimit : Metal + this.Metal;
		this.Concrete = Concrete + this.Concrete > MaterialLimit ? MaterialLimit : Concrete + this.Concrete;
		Refresh();
		Save();
	}

	//讓文字 = 數字
	public void Refresh()
	{
		transform.GetChild(1).GetChild(0).transform.GetComponent<Text>().text = Coin.ToString();
		transform.GetChild(2).GetChild(0).transform.GetComponent<Text>().text = Wood.ToString();
		transform.GetChild(3).GetChild(0).transform.GetComponent<Text>().text = Metal.ToString();
		transform.GetChild(4).GetChild(0).transform.GetComponent<Text>().text = Concrete.ToString();
	}

	//(overload)第一種查詢方法
	public int[] MaterialQuery()
	{
		int[] MaterialLeft = new int[4];
		MaterialLeft[0] = Coin;
		MaterialLeft[1] = Wood;
		MaterialLeft[2] = Metal;
		MaterialLeft[3] = Concrete;

		return MaterialLeft;
	}

	//(overload)第二種查詢方法
	public int MaterialQuery(string query)
	{
		switch (query)
		{
			case "Coin":
				return Coin;
			case "Wood":
				return Wood;
			case "Metal":
				return Metal;
			case "Concrete":
				return Concrete;
			default:
				return 404;
		}
	}

	//存檔
	private void Save()
	{
		//建立物件，塞資料
		SaveFile save = new SaveFile();

		save.Coin = Coin;
		save.Wood = Wood;
		save.Metal = Metal;
		save.Concrete = Concrete;

		string json = JsonConvert.SerializeObject(save);

		//write string to file
		File.WriteAllText(FilePath, json);
	}
}
