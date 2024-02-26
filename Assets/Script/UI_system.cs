using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : Popup
{
    public GameObject UICanvas;
    public GameObject UICanvasPopup;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Init()
    {
        //�˸´� ĵ������ �ִ� ������Ʈ ã��

        PopupMgr.Instance().CanvasParent = UICanvas;

        if (PopupMgr.Instance().CanvasParent == null)
            Debug.Log("not find GUI Object");

        PopupMgr.Instance().CanvasPopup = UICanvasPopup;
        if (PopupMgr.Instance().CanvasPopup == null)
            Debug.Log("not find UICanvas Object");
    }
}
