using System.Collections.Generic;
using UnityEngine;

public class InGameInventory : Inventory
{
    //레벨이 오를시 아이템을 획득 ex)weapon, passiveItem
    //1레벨 당 normalShop 호출//
    //10레벨 당 specialShop 호출//   
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
        //미구현//
    }
    private void CallShop()
    {
        NormalShop();
    }

    public void RandItem()// 아이템 선택지
    {
        for (int i = 0; i < picks.Length; i++)
        {
            int selectIndex = Random.Range(0, itemList.Count);
            picks[i] = itemList[selectIndex];
            itemList.RemoveAt(selectIndex);
        }

        //if (false)//OnClick 선택지.
        //{
        //    itemList.Add(picks[1]);
        //    itemList.Add(picks[2]);
        //}
        //if (true)// OnClick 선택지.
        //{
        //    itemList.Add(picks[0]);
        //    itemList.Add(picks[2]);
        //}
        //if (false)// OnClick 선택지.
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
                    Debug.Log("여기까지 실행 되었는가?1");
                    picks[i] = itemList.table[selectIndex];//오류 발생지점.
                    Debug.Log("여기까지 실행 되었는가?2");
                    CurItem = picks[i];
                    PreItem = CurItem;
                }
            }
        }
        Debug.Log("실행3");
        Debug.Log(picks[0].name);
        Debug.Log(picks[1].name);
        Debug.Log(picks[2].name);
        */
    }
    //public void ChoiceItem()
    //{
    //    Debug.Log("아이템뽑기");

    //    if(Input.GetKeyDown(KeyCode.A))
    //    {
    //        Debug.Log("A선택");                     
    //        items.Add(pickB);
    //        items.Add(pickC);
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        Debug.Log("B선택");            
    //        items.Add(pickA);
    //        items.Add(pickC);

    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        Debug.Log("C선택");                    
    //        items.Add(pickA);
    //        items.Add(pickB);
    //    }
    //}


    //인게임 인벤일 경우

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("아이템뽑기");
        inGameInventroy = collision.gameObject.GetComponent<InGameInventory>();
        //ChoiceItem();

    }//충돌 삭제해도됨.

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
        if (Input.GetKeyDown(KeyCode.L))// 확인용
        {
            NormalShop();
        }
    }
}
