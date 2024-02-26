using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public ItemDataTable data = null;
    List<GameObject> slots;
    public GameObject slotShape;
    public GameObject spawnParents;

    private void Start()
    {
        slots = new List<GameObject>();

        SetStateItem();
        if (data != null)
        {
            for (int i = 0; i < data.table.Count; i++)
            {
                slots.Add(Instantiate(slotShape, spawnParents.transform));
                slots[i].gameObject.name = data.table[i].name;
                //ItemMgr.Instance().StateCount++;
            }

            //ItemMgr.Instance().StateCount = 0;
        }
        Setslots();
    }

    private void Update()
    {

    }

    void SetStateItem()
    {
        // 플레이어의 스탯 데이터 리스트와, 아이템 매니저 뿌려야 하는 스탯의 데이터 리스트를 동일하게 맞춘다.
        ItemMgr.Instance().dataState = data;
        //Debug.Log(ItemMgr.Instance().data.table[0].name);
    }

    void Setslots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].gameObject.AddComponent<Useable>();
            slots[i].GetComponent<Useable>().Init(data.table[i]);
            slots[i].GetComponent<Useable>().E_type = Types.State;
        }
    }
}
