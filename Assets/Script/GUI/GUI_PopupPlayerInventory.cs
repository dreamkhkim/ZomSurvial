using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_PopupPlayerInventory : Popup
{
    public GameObject exit;
    public GameObject itemShape;
    public GameObject spawnParents;

    public TextMeshProUGUI hpLabel;
    public TextMeshProUGUI attackLabel;
    public TextMeshProUGUI speedLabel;

    List<GameObject> newObjs;

    private void OnEnable()
    {
        Init(exit);
        userStateTypes = UserStateType.Inventory;
        GameManager.userStateType = userStateTypes;

        // �κ��丮�� ���� �� ������ ������ �ִ� �����۵��� �����ؼ� �����ش�.
        newObjs = new List<GameObject>();

        for (int i = 0; i < Inventory.Instance().items.Count; i++)
        {
            newObjs.Add(Instantiate(itemShape, spawnParents.transform)); // ������ ������Ʈ ����
            SetItemsClass(i); // ������ ���� ����
            Inventory.Instance().items[i] = newObjs[i].GetComponent<Item>();
            Inventory.Instance().ItemIndex++; // ������ �ִ� �������� ���� ���� (������ UI�� �ݿ��ϱ� ���ؼ�)
        }

        Inventory.Instance().ItemIndex = 0;
    }

    private void Update()
    {
        hpLabel.text = GameManager.Hp.ToString();
        attackLabel.text = GameManager.Attack.ToString();
        speedLabel.text = GameManager.Speed.ToString();


    }


    public override void Init(GameObject exit)
    {
        BtnExit = exit.GetComponent<Button>();
        BtnExit.onClick.AddListener(() => PopupMgr.Instance().ClosePopup(this.gameObject));
    }

    void SetItemsClass(int i)
    {
        switch (Inventory.Instance().items[i].E_type)
        {
            case Types.Weapon:
                {
                    newObjs[i].gameObject.AddComponent<Weapon>();
                    newObjs[i].GetComponent<Weapon>().Init(Inventory.Instance().items[i]);
                }
                break;
            case Types.Top:
            case Types.Bottom:
            case Types.Shoose:
                {
                    newObjs[i].gameObject.AddComponent<Equipment>();
                    newObjs[i].GetComponent<Equipment>().Init(Inventory.Instance().items[i]);
                }
                break;
        }

        newObjs[i].GetComponent<Item>().index += i;
        newObjs[i].gameObject.name = Inventory.Instance().items[i].name;
    }
}
