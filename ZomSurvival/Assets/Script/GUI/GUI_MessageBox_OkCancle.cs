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
            if (result.gameObject.GetComponent<Button>() != null) // �̰� ��¥ �ϵ��ڵ�..;; �̸� �ٲ�� ������ �����.
            {
                Debug.Log("Hit");
                item = result.gameObject.GetComponentInParent<Item>();
            }
        }

        if (item != null)
        {
            Debug.Log(item.gameObject);

            ItemMgr.Instance().PickItem = item; // �������� Ŭ���� �������� ����

            if (GameManager.Coin >= item.price)
            {
                GameManager.Coin -= item.price; // ���� �����ϱ�
                Inventory.Instance().items.Add(item);// �κ��丮�� �ֱ�
            }
            else
            {
                //���� �Ұ� ��Ȳ �۾� ������
            }
            
            ItemMgr.Instance().PickItem = null; // pickitem �ʱ�ȭ
        }
        PopupMgr.Instance().ClosePopup(this.gameObject);
    }

    void OnClickCancle()
    {
        Debug.Log("cancle");

        PopupMgr.Instance().ClosePopup(this.gameObject);
    }
}
