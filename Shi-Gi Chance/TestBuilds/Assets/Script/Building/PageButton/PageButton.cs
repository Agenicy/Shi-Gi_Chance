using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageButton : MonoBehaviour
{

	[SerializeField] int Page;//目前的按鈕式第幾分頁(0~2)

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	//////////////
	
	//按鈕被點選時，切換分頁
	public void SwitchPage()
	{
		//BGS
		BGS();
	
		//change display
		InActiveAll();
		ActiveThis();

		FreshReader();
	}

	private void InActiveAll()
	{
		GameObject parent = this.transform.parent.gameObject;
		for (int i = 0; i < 3; i++)
		{
			GameObject child = parent.transform.GetChild(i).gameObject;
			child.GetComponent<Image>().color = new Color32(186, 186, 186, 255);//default non-active color
		}
	}

	private void ActiveThis()
	{
		this.GetComponent<Image>().color = new Color32(226, 226, 226, 255);//default active color
	}

	private void BGS()
	{
		transform.parent.GetComponent<AudioSource>().Play();
	}

	private void FreshReader()
	{
		GameObject Reader = transform.parent.parent.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
		Reader.GetComponent<SectionReader>().ClearReader();
		Reader.GetComponent<SectionReader>().SetReader(Page);
		Reader.GetComponent<SectionReader>().ScrollToTop();
	}
}
