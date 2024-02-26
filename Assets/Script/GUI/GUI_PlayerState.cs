using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GUI_PlayerState : Popup
{
    public GameObject exit;
    public GameObject ItemSlot;

    private void Start()
    {

    }
    void OnEnable()
    {
        userStateTypes = UserStateType.State;
        GameManager.userStateType = userStateTypes;
        Init(exit);
    }

    void Update()
    {
        
    }

    public override void Init(GameObject exit)
    {
        BtnExit = exit.GetComponent<Button>();
        BtnExit.onClick.AddListener(() => PopupMgr.Instance().ClosePopup(this.gameObject));
        //슬롯 생성해야 한다.
    }
}
