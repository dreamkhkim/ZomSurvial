using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMgr
{
    static ItemMgr itemMgr = null; // ΩÃ±€≈Ê
    static int itemCount = 0;
    static int stateCount = 0;

    public ItemDataTable dataShop = null;
    public ItemDataTable dataState = null;
    public List<RaycastResult> Objs = new List<RaycastResult>();

    static Item pickItem = null;
    static bool isUsedItem = false;

    public static ItemMgr Instance()
    {
        if (itemMgr == null)
        {
            itemMgr = new ItemMgr();
        }
        return itemMgr;
    }

    public int ItemCount
    { get { return itemCount; } set { itemCount = value; } }

    public int StateCount
    { get { return stateCount; } set { stateCount = value; } }

    public Item PickItem
    { get { return pickItem; } set { pickItem = value; } }

    public bool IsUsedItem
    { get { return isUsedItem; } set { isUsedItem = value; } }

}
