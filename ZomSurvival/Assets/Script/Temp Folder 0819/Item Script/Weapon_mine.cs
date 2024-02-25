using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_mine : MonoBehaviour //인게임에서 얻을수있는 아이템//
{
    //공격력//
    
    public int atk;         // 기본공격력//
    public int power;       // 밀치는 힘//
    public int critical;    // 크리율 //
    public bool isPierce;   // 무기가 관통되는가 //
    public bool isBound;    // 무기가 튕기는가 //
    public int wpnLv = 1;   // 무기 기본레벨

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


    enum WeaponAttackType//아이템의 공격타입// 
    {
        MeleeWpn,
        RangeWpn
    }

       

    
    void Attack() //공격//
    {
        

    }

    void ReinforceWeapon()//상점에서 같은 무기를 골랐을떄 호출되는 무기 강화 기능//
    {

    }




    void Start()
    {
      
    }

    
    void FixedUpdate()
    {
        

    }
}

