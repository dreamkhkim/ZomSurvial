using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    static Inventory iven = null; // �̱���
    public List<Item> items = new List<Item>();

    public List<Item> InGameItems = new List<Item>(); //�ΰ��� ������ ����Ʈ
    public List<Weapon> InGameGetItemWeapon = new List<Weapon>(4); // �����
    public List<PassiveItem> InGameGetItemPassiveItem = new List<PassiveItem>(4); // ������
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
