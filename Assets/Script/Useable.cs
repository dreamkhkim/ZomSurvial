using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Useable : Item
{
    public EffectType EeffectType = EffectType.None;
    public int stateValue;
    public int skillValue;
    private void Start()
    {

    }

    public override void Init(ScriptableObjItem inputData)
    {
        index = inputData.Item.index;
        EeffectType = inputData.Item.E_effectType;
        name = inputData.Item.name;
        img = inputData.Item.img;
        level = inputData.Item.level;
        price = inputData.Item.price;
        infomation = inputData.Item.infomation;
        stateValue = inputData.Item.stateValue;
        skillValue = inputData.Item.skillValue;
    }

    public override void Init(Item inputItem)
    {
        Useable item = (Useable)inputItem;
        E_type = item.E_type;
        name = item.name;
        img = item.img;
        level = item.level;
        price = item.price;
        infomation = item.infomation;

        if (item.EeffectType == EffectType.Hp)
            stateValue = item.stateValue + (GameManager.Hp + item.stateValue) * item.skillValue;
        else if((item.EeffectType == EffectType.Attack))
            stateValue = item.stateValue + (GameManager.Attack + item.stateValue) * item.skillValue;
    }

    public override void Use()
    {
        GameManager.TakeState(this);
        GameManager.Coin -= this.price;
    }

    public override void Release()
    {
        throw new System.NotImplementedException();
    }
}
