using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class GUI_SlotCreator : MonoBehaviour
{
    public GameObject itemSlot; //복사할 객체

    [SerializeField] ItemDataTable itemDataTable = null;
    [SerializeField] static List<GameObject> itemSlots;

    void Start()
    {
        if(itemDataTable != null)
        {
            itemSlots = new List<GameObject>();
        }

        if(itemSlots != null)
        {
            CreateSlot();
        }
    }

    void CreateSlot()
    {
        //for (int i = 0; i < itemDataTable.table.Count; i++)
        //{
        //    //고유하게 물고서 매니저한테 복사해주는게 낫겠다.
        //    itemSlots.Add(Instantiate(itemSlot, transform));

        //    if (itemSlots[i] != null)
        //    {
        //        itemSlots[i].GetComponent<GUI_Slot>().Data = itemDataTable.table[i]; // 테이블에 있는 정보를 복사해서 주고.
        //        itemSlots[i].GetComponent<GUI_Slot>().SetInformation(); // 정보 Set

        //        if (GameManager.userStateType == UserStateType.State) // 지금 보고 있는 팝업이 스탯창이면
        //        {
        //            if (itemSlots[i].GetComponent<GUI_Slot>().useableType == UseableType.None)
        //            {
        //                itemSlots[i].GetComponent<GUI_Slot>().SetSlotDimmed();
        //            }  
        //        }
        //    }
        //}
    }
}
