using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : Item //�ΰ��ӿ��� ���� �� �ִ� ���� ��� ������//
{
    protected float buffValue;

    public override void Init(ScriptableObjItem inputData)
    {
        name = inputData.Item.name;
        img = inputData.Item.img;
        level = inputData.Item.level;
        price = inputData.Item.price;
        infomation = inputData.Item.infomation;
        buffValue = inputData.Item.buffValue;
    }

    public override void Release()
    {
        throw new System.NotImplementedException();
    }

    public override void Use()
    {
        //
    }
}
