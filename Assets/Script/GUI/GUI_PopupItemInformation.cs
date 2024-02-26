using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GUI_PopupItemInformation : Popup
{
    public GameObject exit;
    public GameObject equipWeapon;
    public GameObject equipArrmor;
    public GameObject equipmentInfo;
    public GameObject weaponInfo;
    public GameObject BtnWeaponLabel;
    public GameObject BtnEquipmentLabel;

    TextMeshProUGUI cBtnWeaponLabel;
    TextMeshProUGUI cBtnEquipmentLabel;

    Button cBtnEquipWeapon;
    Button cBtnEquipEquipment;

    void Start()
    {

    }

    void OnEnable()
    {
        Init();

        switch (ItemMgr.Instance().PickItem.E_type)
        {
            case Types.Weapon:
                {
                    weaponInfo.SetActive(true);
                    equipmentInfo.SetActive(false);
                }
                break;
            case Types.Top:
            case Types.Bottom:
            case Types.Shoose:
                {
                    equipmentInfo.SetActive(true);
                    weaponInfo.SetActive(false);
                }
                break;
            default:
                break;
        }

        if (ItemMgr.Instance().PickItem.isUse)
        {
            cBtnWeaponLabel.text = "Release";
            cBtnEquipmentLabel.text = "Release";
        }
        else
        {
            cBtnWeaponLabel.text = "Get";
            cBtnEquipmentLabel.text = "Get";
        }
    }

    void Init()
    {
        BtnExit = exit.GetComponent<Button>();
        cBtnEquipWeapon = equipWeapon.GetComponent<Button>();
        cBtnEquipEquipment = equipArrmor.GetComponent<Button>();
        cBtnWeaponLabel = BtnWeaponLabel.GetComponent<TextMeshProUGUI>();
        cBtnEquipmentLabel = BtnEquipmentLabel.GetComponent<TextMeshProUGUI>();

        BtnExit.onClick.AddListener(() => PopupMgr.Instance().ClosePopup(this.gameObject));
        cBtnEquipWeapon.onClick.AddListener(() => OnClick(ItemMgr.Instance().PickItem.isUse));
        cBtnEquipEquipment.onClick.AddListener(() => OnClick(ItemMgr.Instance().PickItem.isUse));
    }

    void OnClick(bool isUsed)
    {
        if(isUsed)
        {
            ItemMgr.Instance().PickItem.Release();

            for (int i = 0; i < Inventory.Instance().items.Count; i++)
            {
                if (Inventory.Instance().items[i].index ==ItemMgr.Instance().PickItem.index)
                {
                    Inventory.Instance().items[i].isUse = false;
                }
            }

        }
        else
        {
            ItemMgr.Instance().PickItem.Use();

            for(int i = 0; i < Inventory.Instance().items.Count; i++)
            {
                if (Inventory.Instance().items[i].index == ItemMgr.Instance().PickItem.index)
                {
                    Inventory.Instance().items[i].isUse = true;
                }
            }
        }
        PopupMgr.Instance().ClosePopup(this.gameObject);
    }
}