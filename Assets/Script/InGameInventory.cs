using System.Collections.Generic;
using UnityEngine;

public class InGameInventory : Inventory
{
    //������ ������ �������� ȹ�� ex)weapon, passiveItem
    //1���� �� normalShop ȣ��//
    //10���� �� specialShop ȣ��//   
    public GameObject battleObj;
    //public List<Item> items;
    private Player player;
    //private Item inGameItem;
    public PassiveItem inShopPassiveItem;
    public Weapon inShopWeapon;
    private InGameInventory inGameInventroy;

    public ScriptableObjItem[] picks;
    // ItemDataTable itemList;
    List<ScriptableObjItem> itemList;

    private void NormalShop()
    {
        RandItem();
    }
    private void SpecialShop()
    {
        //�̱���//
    }
    private void CallShop()
    {
        NormalShop();
    }

    public void RandItem()// ������ ������
    {
        for (int i = 0; i < picks.Length; i++)
        {
            int selectIndex = Random.Range(0, itemList.Count);
            picks[i] = itemList[selectIndex];
            itemList.RemoveAt(selectIndex);
        }

        //if (false)//OnClick ������.
        //{
        //    itemList.Add(picks[1]);
        //    itemList.Add(picks[2]);
        //}
        //if (true)// OnClick ������.
        //{
        //    itemList.Add(picks[0]);
        //    itemList.Add(picks[2]);
        //}
        //if (false)// OnClick ������.
        //{
        //    itemList.Add(picks[0]);
        //    itemList.Add(picks[1]);
        //}

        /*
        Item PreItem = null;
        Item CurItem = null;
        while (picks.Length <= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                while (CurItem == PreItem)
                {
                    int selectIndex = Random.Range(0, itemList.table.Count);
                    Debug.Log("������� ���� �Ǿ��°�?1");
                    picks[i] = itemList.table[selectIndex];//���� �߻�����.
                    Debug.Log("������� ���� �Ǿ��°�?2");
                    CurItem = picks[i];
                    PreItem = CurItem;
                }
            }
        }
        Debug.Log("����3");
        Debug.Log(picks[0].name);
        Debug.Log(picks[1].name);
        Debug.Log(picks[2].name);
        */
    }
    //public void ChoiceItem()
    //{
    //    Debug.Log("�����ۻ̱�");

    //    if(Input.GetKeyDown(KeyCode.A))
    //    {
    //        Debug.Log("A����");                     
    //        items.Add(pickB);
    //        items.Add(pickC);
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        Debug.Log("B����");            
    //        items.Add(pickA);
    //        items.Add(pickC);

    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        Debug.Log("C����");                    
    //        items.Add(pickA);
    //        items.Add(pickB);
    //    }
    //}


    //�ΰ��� �κ��� ���

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("�����ۻ̱�");
        inGameInventroy = collision.gameObject.GetComponent<InGameInventory>();
        //ChoiceItem();

    }//�浹 �����ص���.

    // Start is called before the first frame update
    //void Start()
    //{
    //    battleMgr = battleObj.GetComponent<BattleMgr>();
    //    picks = new ScriptableObjItem[3];
    //    itemList = new List<ScriptableObjItem>();

    //    for (int i = 0; i < pickItemDataTable.table.Count; i++)
    //    {
    //        itemList.Add(battleMgr.inGameItemTable.table[i]);
    //    }
    //    Debug.Log(itemList[0].name);
    //    picks[0] = itemList[0];
    //    Debug.Log(picks[0].name);



    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))// Ȯ�ο�
        {
            NormalShop();
        }
    }
}
