using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class OutGameInventory : MonoBehaviour
{   
    List<string> inGameWeapons;
    List<string> inPassiveItems;

    public Item item;
    public void ClassifyItem()
    {

    }


    public void AddWeaponInGameInventory(string inputWeapon)
    {
        if (inGameWeapons.Count >= 4)
        {
            Debug.Log(" �ִ�ġ�Դϴ� ");
        }
        else
        {
            Debug.Log("���� ����!");
            inGameWeapons.Add(inputWeapon);
        }
    }
    public void AddPassiveItemInGameInventory(string inputPassiveItem)
    {
        if(inPassiveItems.Count >= 4)
        {
            Debug.Log("�ִ�ġ�Դϴ�");
        }
        else
        {        
            Debug.Log("�нú� ������ ����!");        
            inPassiveItems.Add(inputPassiveItem);
        }
    }
    private void ShowItem()
    {
        Debug.Log("���");
        for (int i = 0; i < inGameWeapons.Count; i++)
        {
            Debug.Log(inGameWeapons[i]);
        }
        for(int x = 0; x < inPassiveItems.Count; x++)
        {
            Debug.Log(inPassiveItems[x]);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹");
        
    }


    void Start()
    {
        inGameWeapons = new List<string>();
        inPassiveItems = new List<string>();
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("������ �ִ� ������ ���");
            for(int q = 0; q < inGameWeapons.Count;q++)
            {
                Debug.Log("���� : " + inGameWeapons[q]);
            }
            for (int w = 0; w < inPassiveItems.Count; w++)
            {
                Debug.Log("�нú� ������" + inPassiveItems[w]);
            }
        }
  
    }
}
