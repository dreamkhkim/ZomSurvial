using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_MessageBox_OkCancle : MonoBehaviour
{
    public GameObject okButton;
    public GameObject cancelButton;

    Button okBtn;
    Button cancelBtn;
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        okBtn = okButton.GetComponent<Button>();
        cancelBtn = cancelButton.GetComponent<Button>();

        okBtn.onClick.AddListener(OnClickOk);
        cancelBtn.onClick.AddListener(OnClickCancle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickOk()
    {
        Debug.Log("ok");

        foreach (RaycastResult result in ItemMgr.Instance().Objs)
        {
            if (result.gameObject.GetComponent<Button>() != null) // 이거 진짜 하드코딩..;; 이름 바뀌면 문제가 생긴다.
            {
                Debug.Log("Hit");
                item = result.gameObject.GetComponentInParent<Item>();
            }
        }

        if (item != null)
        {
            Debug.Log(item.gameObject);

            ItemMgr.Instance().PickItem = item; // 상점에서 클릭한 아이템의 정보

            if (GameManager.Coin >= item.price)
            {
                GameManager.Coin -= item.price; // 가격 차감하기
                Inventory.Instance().items.Add(item);// 인벤토리에 넣기
            }
            else
            {
                //구매 불가 상황 작업 못했음
            }
            
            ItemMgr.Instance().PickItem = null; // pickitem 초기화
        }
        PopupMgr.Instance().ClosePopup(this.gameObject);
    }

    void OnClickCancle()
    {
        Debug.Log("cancle");

        PopupMgr.Instance().ClosePopup(this.gameObject);
    }
}
