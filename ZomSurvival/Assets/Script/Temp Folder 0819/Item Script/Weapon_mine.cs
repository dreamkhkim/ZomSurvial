using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_mine : MonoBehaviour //�ΰ��ӿ��� �������ִ� ������//
{
    //���ݷ�//
    
    public int atk;         // �⺻���ݷ�//
    public int power;       // ��ġ�� ��//
    public int critical;    // ũ���� //
    public bool isPierce;   // ���Ⱑ ����Ǵ°� //
    public bool isBound;    // ���Ⱑ ƨ��°� //
    public int wpnLv = 1;   // ���� �⺻����

    [SerializeField]
    ScriptableObject itemInfo;


    public void Init(int atk, int power, int critical)
    {
        this.atk = atk;
        this.power = power;
        this.critical = critical;
        this.isPierce = false;
        this.isBound = false;
    }


    enum WeaponAttackType//�������� ����Ÿ��// 
    {
        MeleeWpn,
        RangeWpn
    }

       

    
    void Attack() //����//
    {
        

    }

    void ReinforceWeapon()//�������� ���� ���⸦ ������� ȣ��Ǵ� ���� ��ȭ ���//
    {

    }




    void Start()
    {
      
    }

    
    void FixedUpdate()
    {
        

    }
}

