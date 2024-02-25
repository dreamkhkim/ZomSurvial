using System;
using UnityEngine;
using UnityEngine.UI;


public enum Types
{
    [HideInInspector] None,
    Weapon = 100,
    Top = 200,
    Bottom = 300,
    Shoose = 400,
    State = 500,

    [HideInInspector] END
}

public enum EffectType
{
    None,
    Hp,
    Defense,
    Attack,

    [HideInInspector] END
}

public enum HowToAttack
{
    None,
    farRange,
    closeRange,
    Area,

    [HideInInspector] END
}

[Serializable]
public class Data
{
    [Header("아이템의 메인 타입")]
    public Types E_type;
    [Header("아이템이 영향주는 스탯")]
    public EffectType E_effectType = EffectType.None;
    [Header("아이템의 공격 방식 - 추가해도 됌")]
    public HowToAttack E_attackType = HowToAttack.None;
    public bool isUsed = false;
    public int index;

    public string name;
    public Sprite img;
    public int level = 1;
    public uint price = 0;
    public int stateValue = 0;
    public string skillName;
    [Header("사용 공식 (GameManager.Attack + item.stateValue) * item.skillValue")]
    public int skillValue = 0;
    public string infomation;
    [Space(10)]
    [Header("buff Value는 passive Item 용으로 추가되어있음")]
    public float buffValue = 1;


}

[CreateAssetMenu(fileName = "ScriptableObjs", menuName = "ScriptableOjbects/ItemData")]
public class ScriptableObjItem : ScriptableObject
{
    [SerializeField]
    private Data item;

    public Data Item
    {
        get { return item; }
    }
}