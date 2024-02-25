using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Popup : MonoBehaviour
{
    Button btnExit;

    [HideInInspector]
    public UserStateType userStateTypes;

    public Button BtnExit
    {
        get { return btnExit; }
        set { btnExit = value; }
    }

    public virtual void Init(GameObject exit)
    {
        btnExit = exit.GetComponent<Button>();
        btnExit.onClick.AddListener(() => PopupMgr.Instance().ClosePopup(this.gameObject));
    }
}
