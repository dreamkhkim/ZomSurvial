using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupMgr
{
    static PopupMgr popupMgr = null; // ΩÃ±€≈Ê
    Stack<GameObject> popups = null;
    bool isDimmed = false;
    GameObject canvasParent = null;
    GameObject canvasPopup = null;

    bool click;

    public static PopupMgr Instance()
    {
        if (popupMgr == null)
        {
            popupMgr = new PopupMgr();
            popupMgr.popups = new Stack<GameObject>();
        }

        return popupMgr;
    }

    public bool IsDimmed { get { return isDimmed; } set { isDimmed = value; } }
    public bool Click { get { return click; } set { click = value; } }
    public GameObject CanvasParent { get { return canvasParent; } set { canvasParent = value; } }
    public GameObject CanvasPopup { get { return canvasPopup; } set { canvasPopup = value; } }



    void CreateDimmed(bool isDimmed)
    {
        if (isDimmed == false)
        {
            GameObject instanceDimmed = null;
            instanceDimmed = Behaviour.Instantiate(Resources.Load<GameObject>("Popup/Dimmed"),canvasPopup.transform);
            instanceDimmed.transform.localPosition = Vector3.zero;

            if (instanceDimmed != null)
                IsDimmed = true;

            Debug.Log(IsDimmed);
        }
        else { return; }
    }

    void DeleteDimmed()
    {
        if(IsDimmed)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Dimmed");
            Debug.Log(temp.gameObject.name);
            Behaviour.Destroy(temp.gameObject);

            IsDimmed = false;
        }
    }
    public void OpenPopup(string prefabName)
    {
        GameObject instancePopup = null;

        if (isDimmed == false && prefabName != null)
        {
            CreateDimmed(isDimmed);
        }
        else
        {
            DeleteDimmed();
            CreateDimmed(isDimmed);
        }

        instancePopup = Behaviour.Instantiate(Resources.Load<GameObject>("Popup/" + prefabName), canvasPopup.transform);
        instancePopup.transform.localPosition = Vector3.zero;
        
        if(instancePopup != null)
            popups.Push(instancePopup);


    }

    public void ClosePopup(GameObject curPopup)
    {
        GameObject topPopup = popups.Peek();

        if (topPopup != null)
        {
            if (curPopup == topPopup)
            {
                popups.Pop();
                DeleteDimmed();
                Behaviour.Destroy(curPopup);
            }

            if(popups.Count <= 0)
            {
                GameManager.userStateType = UserStateType.Main;
            }

            ItemMgr.Instance().ItemCount = 0;
            ItemMgr.Instance().PickItem = null;
        }
        else return;
    }

    public void DisablePopup(GameObject curPopup)
    {
        curPopup.SetActive(false);
    }

    public void ActivePopup(GameObject curPopup)
    {
        curPopup.SetActive(true);
    }

    public Stack<GameObject> Popups
    {
        get { return popups; }
    }
}
