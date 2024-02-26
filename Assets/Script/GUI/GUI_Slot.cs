using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class GUI_Slot : MonoBehaviour
{
    [Header("Chain Objects")]
    [Space(5)]
    public GameObject getBottn;
    public GameObject sprite;
    public GameObject nameLabel;
    public GameObject level;
    //public GameObject coinLabel;
    public GameObject itemInfo;
    public GameObject skillName;
    public GameObject price;
    public GameObject dimmed;

    public GameObject equipDimmedObject;

    Button btnGet;
    Image cSprite;
    TextMeshProUGUI cNameLabel;
    TextMeshProUGUI cLevel;
    //TextMeshProUGUI cCoinLabel;
    TextMeshProUGUI cItemInfo;
    TextMeshProUGUI cSkillValue;
    TextMeshProUGUI cPrice;

    GameObject obj;

    private void Start()
    {
        if (GameManager.userStateType == UserStateType.State)
        {
            Useable temp = GetComponent<Useable>();

            if (temp != null)
                SetInformation(temp.index);

            if (this.GetComponent<Useable>() != null)
            {
                if (this.GetComponent<Useable>().isUse)
                    Disable(true);
            }
        }
    }

    private void OnEnable()
    {
        Init();

        if (GameManager.userStateType == UserStateType.Shop)
        {
            SetInformation(ItemMgr.Instance().ItemCount);
        }
        else if (GameManager.userStateType == UserStateType.Inventory)
        {
            SetInformation(Inventory.Instance().ItemIndex);
        }

        if (btnGet != null)
            btnGet.onClick.AddListener(() => onClick());
    }

    private void Update()
    {
        if (GameManager.userStateType == UserStateType.Inventory)
        {
            if (this.GetComponent<Item>().isUse)
            {
                equipDimmedObject.SetActive(true);
            }
            else
            {
                equipDimmedObject.SetActive(false);
            }
        }
    }

    void Init()
    {
        if (getBottn != null) btnGet = getBottn.GetComponent<Button>();
        if (sprite != null) cSprite = sprite.GetComponent<Image>();
        if (nameLabel != null) cNameLabel = nameLabel.GetComponent<TextMeshProUGUI>();
        if (level != null) cLevel = level.GetComponent<TextMeshProUGUI>();
        //cCoinLabel = coinLabel.GetComponent<TextMeshProUGUI>();
        if (itemInfo != null) cItemInfo = itemInfo.GetComponent<TextMeshProUGUI>();
        if (price != null) cPrice = price.GetComponent<TextMeshProUGUI>();
        if(cSkillValue != null) cSkillValue = skillName.GetComponent<TextMeshProUGUI>();
    }


    void Disable(bool isUsed)
    {
        if (dimmed != null)
        {
            dimmed.SetActive(true);
            btnGet.gameObject.SetActive(false);
        }
    }

    public void SetInformation(int index)
    {

        if (GameManager.userStateType == UserStateType.Shop)
        {
            ScriptableObjItem data = ItemMgr.Instance().dataShop.table[index];

            if(data != null)
            {
                SetDatas(data);
            }
        }
        else if (GameManager.userStateType == UserStateType.Inventory)
        {
            List<Item> items = Inventory.Instance().items;

            if (items != null)
            {
                SetDatas(items, index);
            }
            
        }
        else if (GameManager.userStateType == UserStateType.State)
        {
            ScriptableObjItem data = ItemMgr.Instance().dataState.table[index];

            if (data != null)
            {
                SetDatas(data);
                this.GetComponent<Useable>().isUse = data.Item.isUsed;
            }
        }
    }

    void SetDatas(ScriptableObjItem data)
    {
        if (cNameLabel != null) cNameLabel.text = data.Item.name;
        if (cSprite != null) cSprite.sprite = data.Item.img;
        if (cLevel != null) cLevel.text = data.Item.level.ToString();
        if (cItemInfo != null) cItemInfo.text = data.Item.infomation;
        if (cPrice != null) cPrice.text = data.Item.price.ToString();
        if (cSkillValue != null) cSkillValue.text = data.Item.skillName;
    }

    void SetDatas(List<Item> item, int index)
    {
        if (cNameLabel != null) cNameLabel.text = item[index].name;
        if (cSprite != null) cSprite.sprite = item[index].img;
        if (cLevel != null) cLevel.text = item[index].level.ToString();
        if (cItemInfo != null) cItemInfo.text = item[index].infomation;
        if (cPrice != null) cPrice.text = item[index].ToString();

        if (item[index].E_type == Types.Weapon)
        {
            Weapon temp = (Weapon)item[index];
            if (cSkillValue != null) cSkillValue.text = temp.skillValue.ToString();
        }
        else if (item[index].E_type != Types.None)
        {
            Equipment temp = (Equipment)item[index];
            if (cSkillValue != null) cSkillValue.text = temp.skillValue.ToString();
        }
    }

    bool onClick() // 버튼을 눌렀을 때 일어날 함수
    {
        switch (GameManager.userStateType)
        {
            case UserStateType.State:
                {
                    if (!GetComponent<Useable>().isUse)
                    {
                        obj = this.gameObject.GetComponent<Useable>().gameObject;
                        obj.GetComponent<Useable>().isUse = true;
                        GameManager.Coin -= obj.GetComponent<Useable>().price;
                        obj.GetComponentInParent<PlayerState>().data.table[obj.GetComponent<Useable>().index].Item.isUsed = true; 

                        Disable(true);
                    }
                }
                break;
            case UserStateType.Shop:
                {
                    PopupMgr.Instance().Click = true;
                    PopupMgr.Instance().OpenPopup("GUI_MessageBox_OkCancle");
                }
                break;
            case UserStateType.Inventory:
                {
                    obj = this.gameObject.GetComponent<Item>().gameObject;
                    ItemMgr.Instance().PickItem = obj.GetComponent<Item>();
                    Debug.Log("인벤토리에서 아이템이 선택 되었다." + ItemMgr.Instance().PickItem.name);
                    PopupMgr.Instance().OpenPopup("GUI_PopupItemInformation");
                }
                break;
            default:
                break;
        }
        return true;
    }
}
