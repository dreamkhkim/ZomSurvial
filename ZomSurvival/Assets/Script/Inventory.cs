using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    static Inventory iven = null; // 싱글톤
    public List<Item> items = new List<Item>();

    public List<Item> InGameItems = new List<Item>(); //인게임 아이템 리스트
    public List<Weapon> InGameGetItemWeapon = new List<Weapon>(4); // 무기들
    public List<PassiveItem> InGameGetItemPassiveItem = new List<PassiveItem>(4); // 버프들
    public Item pickItem = null;

    static int itemIndex = 0;
    public static Inventory Instance()
    {
        if (iven == null)
        {
            iven = new Inventory();
        }
        return iven;
    }
    public int ItemIndex
    { get { return itemIndex; } set { itemIndex = value; } }

}
