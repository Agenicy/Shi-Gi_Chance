using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script名稱不要有空格，一樣每個字大寫
public class EXAMPLE : MonoBehaviour
{
	/*
	用在Awake 、Start 、Update的變數統一集在這裡
	用一行註解 + 一行空白分開

	所有變數都宣告public或者private
	只有private會視需要加上[SerilizeField]
	*/
	public GameObject Var1ForAwake;
	private GameObject Var2ForAwake;
	///////////////////

	[SerializeField] GameObject Var3ForStart;

	/////////////////
	[SerializeField] GameObject Var4ForUpdate;

	//這三個一定最上面
	private void Awake()
	{

	}

	private void Start()
	{

	}

	private void Update()
	{

	}

	////////////////////
	/*
	所有其它會在函式裡面用到的變數放在函式前面
	變數前用一行空白 + 一行註解分開

	Awake 、Start 、Update之後放系統預設函式
	例如OnCollisionEnter, OnKeyDown之類的
	*/
	private void OnCollisionEnter(Collision col)
	{

	}

	//////////////////
	public GameObject FuncVar1;
	public GameObject FuncVar2;
	private GameObject FuncVar3;
	[SerializeField] private GameObject FuncVar4;
	/*
	函式名稱命名 : 以功能命名
	基本上一個名詞+一個動詞
	越少字越好
	然後每個首字都大寫
	例如
	叫做Test的按鈕被按下去
	TestButtonPushed
	切換畫面
	SceneChange
	呼叫Test視窗
	TestWindowShow

	同類型的函式名稱格式一樣
	如果
	向前走
	FrontWalk
	就
	向左走
	LeftWalk
	*/
	void function()
	{
		//for迴圈的變數在括號裡宣告
		//這種的臨時變數小寫開頭
		for (int temp = 0; temp < 100; ++temp)
		{
			FuncInFunc();
		}
	}

	public GameObject FuncInFuncVar1;

	private void FuncInFunc()
	{
		//註解放在上一行
		//根要註解的動作齊頭
		//Tell what is going to happen to FuncInFuncVar1
		//FuncInFuncVar1 = /* ??? */
	}
	//如果會在自定義函數裡面用到自定義函數
	//兩個之間不要用註解分開

	///////////////////
	//未完成的函式連同變數一起整塊註解掉
	/*	public GameObject UnfinishedFuncVar1;
		void UnfinishedFuncVar1()
		{

		}
	*/
	///////////////////
};

