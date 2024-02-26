using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using JetBrains.Annotations;

public class GUI_Main : Popup
{
    public GameObject battleStart;
    public GameObject shop;
    public GameObject state;
    public GameObject inven;
    public GameObject option;
    public GameObject coin;
    public GameObject energy;

    Button btnStart;
    Button btnShop;
    Button btnState;
    Button btnInven;
    Button btnOption;
    TextMeshProUGUI textCoin;
    TextMeshProUGUI textEnergy;

    private void OnEnable()
    {
        GameManager.userStateType = UserStateType.Main;
    }

    private void Start()
    {
        userStateTypes = UserStateType.Main; // 메인 화면일 때
        GameManager.userStateType = userStateTypes;
        //GameManager.InitGameManager(30, 1000, 50, 0, 0, 0, 0, 0, 0); // 메인화면에서 게임매니저 초기화
        Init(); // 메인화면 세팅
    }

    private void Update()
    {
        textCoin.text = GameManager.Coin.ToString();
        textEnergy.text = GameManager.Energy.ToString();
    }

    void Init()
    {
        btnStart = battleStart.GetComponent<Button>();
        btnStart.onClick.AddListener(() => SceneMgr.Instance().CallScene("BattleScene")); //이거는 람다식

        btnShop = shop.GetComponent<Button>();
        btnShop.onClick.AddListener(() => PopupMgr.Instance().OpenPopup("GUI_Popup_Shop"));
        btnState = state.GetComponent<Button>();
        btnState.onClick.AddListener(() => PopupMgr.Instance().OpenPopup("GUI_PlayerState"));
        btnInven = inven.GetComponent<Button>();
        btnInven.onClick.AddListener(() => PopupMgr.Instance().OpenPopup("GUI_PopupPlayerInventory"));

        textCoin = coin.GetComponent<TextMeshProUGUI>();
        textCoin.text = GameManager.Coin.ToString();
        textEnergy = energy.GetComponent<TextMeshProUGUI>();
        textEnergy.text = GameManager.Energy.ToString();
        //btnOption = inven.GetComponent<Button>();
        //btnOption.onClick.AddListener(() => PopupMgr.Instance().OpenPopup(""));
    }
}
