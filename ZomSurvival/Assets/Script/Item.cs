using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public Types E_type;
    public int index;
    public new string name;
    public Sprite img;
    public int level;
    public uint price;
    public string infomation;
    public bool isUse = false;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public virtual void Init(ScriptableObjItem inputData)
    {
        E_type = inputData.Item.E_type;
        name = inputData.Item.name;
        img = inputData.Item.img;
        level = inputData.Item.level;
        price = inputData.Item.price;
        infomation = inputData.Item.infomation;
        isUse = inputData.Item.isUsed;
    }
    public virtual void Init(Item inputItem)
    {
        E_type = inputItem.E_type;
        name = inputItem.name;
        img = inputItem.img;
        level = inputItem.level;
        price = inputItem.price;
        infomation = inputItem.infomation;
        isUse = inputItem.isUse;
    }

    public abstract void Use();
    public abstract void Release();
}
