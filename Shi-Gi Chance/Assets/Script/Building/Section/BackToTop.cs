using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBtnClick()
	{
		transform.parent.GetComponent<SectionReader>().ScrollToTop();
	}
}
