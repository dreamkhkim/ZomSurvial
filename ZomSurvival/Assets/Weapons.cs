using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public Weapon[] guns;

    public ScriptableObjItem[] gunsDatas;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< guns.Length; i++)
        {
            guns[i].GetComponent<Weapon>().Init(gunsDatas[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemMgr.Instance().PickItem != null)
        {
            if (ItemMgr.Instance().PickItem.index == guns[0].GetComponent<Weapon>().index)
            {
                guns[0].gameObject.SetActive(true); //дя
                guns[0].GetComponent<SpriteRenderer>().sprite = ItemMgr.Instance().PickItem.img;
            }
            else if (ItemMgr.Instance().PickItem.index == guns[1].GetComponent<Weapon>().index)
            {
                guns[1].gameObject.SetActive(true); //дя
                guns[1].GetComponent<SpriteRenderer>().sprite = ItemMgr.Instance().PickItem.img;
            }
            else if (ItemMgr.Instance().PickItem.index == guns[2].GetComponent<Weapon>().index)
            {
                guns[2].gameObject.SetActive(true); //дя
                guns[2].GetComponent<SpriteRenderer>().sprite = ItemMgr.Instance().PickItem.img;
            }

            ItemMgr.Instance().PickItem = null;
        }

    }
}
