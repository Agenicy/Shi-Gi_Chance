using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {
	[SerializeField] AudioClip Decide;

	private float Alpha;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Enter()
	{
		GetComponent<AudioSource>().clip = Decide;
		GetComponent<AudioSource>().Play();

		InvokeRepeating("FadeOut", 0, 0.01f);
	}

	private byte alpha = 0;
	private void FadeOut()
	{
		if (alpha == 255)
		{
			SceneManager.LoadScene(0);
		}
		else
		{
			transform.parent.GetChild(3).gameObject.SetActive(true);
			alpha++;
			transform.parent.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, alpha);
		}
	}
}
