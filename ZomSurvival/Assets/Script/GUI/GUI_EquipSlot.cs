using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GUI_EquipSlot : MonoBehaviour
{
    public GameObject itemImg;
    public GameObject itemName;
    public GameObject itemInfo;

    Image cItemImg;
    TextMeshProUGUI cItemName;
    TextMeshProUGUI cItemInfo;

    Item item;
    void Start()
    {
    }

    private void OnEnable()
    {
        if (itemImg != null) cItemImg = itemImg.GetComponent<Image>();
        if (itemName != null) cItemName = itemName.GetComponent<TextMeshProUGUI>();
        if (itemInfo != null) cItemInfo = itemInfo.GetComponent<TextMeshProUGUI>();

        item = ItemMgr.Instance().PickItem;

        if (item.E_type == Types.None)
        {
            return;
        }

        if (item.E_type == Types.Weapon)
        {
            SetDatas((Weapon)item);
            itemImg.SetActive(true);
        }
        else if (item.E_type != Types.None)
        {
            SetDatas((Equipment)item);
            itemImg.SetActive(true);
        }

    }
    void Update()
    {
        
    }

    Equipment SetDatas(Equipment item)
    {
        this.GetComponent<Equipment>().Init(item);
        if (cItemName != null) cItemName.text = item.name;
        if (cItemImg != null) cItemImg.sprite = item.img;
        if (cItemInfo != null) cItemInfo.text = item.infomation;

        return item;
    }

    Weapon SetDatas(Weapon item)
    {
        this.GetComponent<Weapon>().Init(item);
        if (cItemName != null) cItemName.text = item.name;
        if (cItemImg != null) cItemImg.sprite = item.img;
        if (cItemInfo != null) cItemInfo.text = item.infomation;

        return item;
    }
}
