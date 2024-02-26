using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class GUI_SlotCreator : MonoBehaviour
{
    public GameObject itemSlot; //������ ��ü

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
        //    //�����ϰ� ���� �Ŵ������� �������ִ°� ���ڴ�.
        //    itemSlots.Add(Instantiate(itemSlot, transform));

        //    if (itemSlots[i] != null)
        //    {
        //        itemSlots[i].GetComponent<GUI_Slot>().Data = itemDataTable.table[i]; // ���̺� �ִ� ������ �����ؼ� �ְ�.
        //        itemSlots[i].GetComponent<GUI_Slot>().SetInformation(); // ���� Set

        //        if (GameManager.userStateType == UserStateType.State) // ���� ���� �ִ� �˾��� ����â�̸�
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
