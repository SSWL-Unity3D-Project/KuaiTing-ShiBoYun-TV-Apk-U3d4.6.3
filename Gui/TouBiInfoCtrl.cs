﻿using System;
using UnityEngine;
using System.Collections;

public class TouBiInfoCtrl : MonoBehaviour {

	public UISprite CoinNumSetTex;
	public UISprite m_InsertNumS;
	public UISprite m_InsertNumG;
	public AudioSource m_TbSource;
	public GameObject FreeObj;
	public GameObject TouBiObj;

	private int m_InserNum = 0;
	private string CoinNumSet = "";
	private string InsertCoinNum = "";
	private string GameMode = "";
	public static bool IsCloseDongGan;
	public static bool IsCloseQiNang;

	// Use this for initialization
	void Start()
	{
		IsCloseQiNang = false;
		IsCloseDongGan = false;
		GameMode = ReadGameInfo.GetInstance ().ReadGameStarMode();
		if(GameMode == "oper")
		{
			CoinNumSet = ReadGameInfo.GetInstance ().ReadStarCoinNumSet();
			InsertCoinNum = ReadGameInfo.GetInstance ().ReadInsertCoinNum();
			CoinNumSetTex.spriteName = CoinNumSet;
			m_InserNum = Convert.ToInt32(InsertCoinNum);
			UpdateInsertCoin();

			TouBiObj.SetActive(true);
			FreeObj.SetActive(false);
		}
		else {
			TouBiObj.SetActive(false);
			FreeObj.SetActive(true);
		}
		
		InputEventCtrl.GetInstance().ClickSetEnterBtEvent += ClickSetEnterBtEvent;
		InputEventCtrl.GetInstance().ClickCloseDongGanBtEvent += ClickCloseDongGanBtEvent;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (pcvr.bIsHardWare) {
			if (GlobalData.CoinCur != m_InserNum && GameMode == "oper") {
				m_InserNum = GlobalData.CoinCur - 1;
				OnClickInsertBt();
			}
		}
		else {
			if (Input.GetKeyDown(KeyCode.T) && GameMode == "oper") {
				OnClickInsertBt();
			}
		}
	}
	
	void ClickSetEnterBtEvent(ButtonState val)
	{
		if (val == ButtonState.DOWN) {
			return;
		}
		XkGameCtrl.IsLoadingLevel = true;
		Resources.UnloadUnusedAssets();
		GC.Collect();
		Application.LoadLevel(5);
	}

	void ClickCloseDongGanBtEvent(ButtonState val)
	{
		if (val == ButtonState.DOWN) {
			return;
		}

		if (DongGanCtrl.GetInstance() == null) {
			return;
		}
		IsCloseDongGan = !IsCloseDongGan;
		HandleDongGanUI();
	}

	void HandleDongGanUI()
	{
		if (DongGanCtrl.GetInstance() == null) {
			return;
		}

		if (!IsCloseDongGan) {
			DongGanCtrl.GetInstance().ShowDongGanOpen();
		}
		else {
			DongGanCtrl.GetInstance().ShowDongGanClose();
		}
	}

	void OnClickInsertBt()
	{
		m_TbSource.Play();
		m_InserNum++;
		ReadGameInfo.GetInstance().WriteInsertCoinNum(m_InserNum.ToString());
		UpdateInsertCoin();
	}

	void UpdateInsertCoin()
	{
		int n = 1;
		int num = m_InserNum;
		int temp = num;
		while (num > 9) {
			num /= 10;
			n++;
		}

		if (n > 2) {
			m_InsertNumS.spriteName = "9";
			m_InsertNumG.spriteName = "9";
		}
		else if (n==2) {
			int shiwei = (int)(temp/10);
			int gewei = (int)(temp-shiwei*10);
			m_InsertNumS.spriteName = shiwei.ToString();
			m_InsertNumG.spriteName = gewei.ToString();
		}
		else if (n == 1) {
			m_InsertNumS.spriteName = "0";
			m_InsertNumG.spriteName = temp.ToString();
		}
	}
}
