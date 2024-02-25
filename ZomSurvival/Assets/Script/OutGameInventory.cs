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
            Debug.Log(" 최대치입니다 ");
        }
        else
        {
            Debug.Log("무기 얻음!");
            inGameWeapons.Add(inputWeapon);
        }
    }
    public void AddPassiveItemInGameInventory(string inputPassiveItem)
    {
        if(inPassiveItems.Count >= 4)
        {
            Debug.Log("최대치입니다");
        }
        else
        {        
            Debug.Log("패시브 아이템 얻음!");        
            inPassiveItems.Add(inputPassiveItem);
        }
    }
    private void ShowItem()
    {
        Debug.Log("출력");
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
        Debug.Log("충돌");
        
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
            Debug.Log("가지고 있는 아이템 출력");
            for(int q = 0; q < inGameWeapons.Count;q++)
            {
                Debug.Log("무기 : " + inGameWeapons[q]);
            }
            for (int w = 0; w < inPassiveItems.Count; w++)
            {
                Debug.Log("패시브 아이템" + inPassiveItems[w]);
            }
        }
  
    }
}
