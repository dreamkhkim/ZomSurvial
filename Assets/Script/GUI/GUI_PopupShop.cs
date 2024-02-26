using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_PopupShop : Popup
{
    public GameObject exit;
    public GameObject ItemSlot;
    public GameObject coin;

    TextMeshProUGUI labelCoin;

    private void Start()
    {
        userStateTypes = UserStateType.Shop;
        GameManager.userStateType = userStateTypes;
    }
    void OnEnable()
    {
        Init(exit);
    }

    void Update()
    {
        labelCoin.text = GameManager.Coin.ToString();
    }

    public override void Init(GameObject exit)
    {
        BtnExit = exit.GetComponent<Button>();
        BtnExit.onClick.AddListener(() => PopupMgr.Instance().ClosePopup(this.gameObject));

        labelCoin = coin.GetComponent<TextMeshProUGUI>();
        labelCoin.text = GameManager.Coin.ToString();
    }
}
