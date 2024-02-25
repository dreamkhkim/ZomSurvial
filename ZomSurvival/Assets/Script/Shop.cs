using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ItemDataTable data = null;
    List<GameObject> items;
    public GameObject itemShape;
    public GameObject spawnParents;

    private void Start()
    { 
        items = new List<GameObject>();
        SetShopItem();
        if (data != null)
        {
            for (int i = 0; i < data.table.Count; i++)
            {
                items.Add(Instantiate(itemShape, spawnParents.transform));
                items[i].gameObject.name = data.table[i].name;
                ItemMgr.Instance().ItemCount++;
            }
            ItemMgr.Instance().ItemCount = 0;
        }
        SetItems();
    }

    private void Update()
    {

    }

    void SetShopItem()
    {
        // ������ ���� ������ ������ ����Ʈ��, ������ �Ŵ��� �ѷ��� �ϴ� ������ ������ ����Ʈ�� �����ϰ� �����.
        ItemMgr.Instance().dataShop = data;
        //Debug.Log(ItemMgr.Instance().data.table[0].name);
    }

    void SetItems() //ġȯ�ϰ� �ʹ� ��..
    {
        for(int i = 0; i < items.Count; i++) 
        {
            switch(data.table[i].Item.E_type)
            {
                case Types.Weapon:
                    {
                        items[i].gameObject.AddComponent<Weapon>();
                        items[i].GetComponent<Weapon>().Init(data.table[i]);
                        items[i].GetComponent<Weapon>().E_type = Types.Weapon;
                    }
                    break;
                case Types.Top:
                    {
                        items[i].gameObject.AddComponent<Equipment>();
                        items[i].GetComponent<Equipment>().Init(data.table[i]);
                        items[i].GetComponent<Equipment>().E_type = Types.Top;
                    }
                    break;
                case Types.Bottom:
                    {
                        items[i].gameObject.AddComponent<Equipment>();
                        items[i].GetComponent<Equipment>().Init(data.table[i]);
                        items[i].GetComponent<Equipment>().E_type = Types.Bottom;
                    }
                    break;
                case Types.Shoose:
                    {
                        items[i].gameObject.AddComponent<Equipment>();
                        items[i].GetComponent<Equipment>().Init(data.table[i]);
                        items[i].GetComponent<Equipment>().E_type = Types.Shoose;

                    }
                    break;
            }
        }
    }
}
