using UnityEngine;

public enum UserStateType
{
    Main,
    State,
    Shop,
    Inventory,
    Battle,

    END
}

// 게임 매니저는 2개여서는 안된다.
public class GameManager : MonoBehaviour
{
    public static UserStateType userStateType = UserStateType.Main;

    //player---------------------------------------------------------------------------------//
    static uint energy = 30; // 배틀 포인트
    static uint coin = 1500; // 재화
    static int level = 1; // 레벨
    static float exp; // 경험치
    static int hp = 0; //  HP
    static int defense = 0; // 방어력
    static int attack = 0; // 공격력
    static float speed = 0f;
    static uint battleCoin = 0;
    //static float buff; // 버프 수치
    //---------------------------------------------------------------------------------------//

    private void Start()
    {
    }

    private void OnEnable()
    {

    }

    public static uint Energy { get { return energy; } set { energy = value; } }
    public static uint Coin { get { return coin; } set { coin = value; } }
    public static int Hp { get { return hp; } set { hp = value; } }
    public static int Level { get { return level; } set { level = value; } }
    public static float Exp { get { return exp; } set { exp = value; } }
    public static float Speed { get { return speed; } set { speed = value; } }
    public static int Defense { get { return defense; } set { defense = value; } }
    public static int Attack { get { return attack; } set { attack = value; } }

    public static uint BattleCoin { get { return battleCoin; } set { battleCoin = value; } }
    //public static float Buff { get { return buff; } set { buff = value; } }

    public static void TakeState(Weapon item)
    {
        if (item.GetComponent<Weapon>().E_type == Types.Weapon)
        {
            Debug.Log("스탯이 적용되었다. Weapon");
            GameManager.Attack += item.stateValue;
        }
    }

    // 장비의 타입에 따라 플레이어의 스탯에 영향을 주게된다.
    public static void TakeState(Equipment item)
    {
        switch (item.GetComponent<Equipment>().E_type)
        {
            case Types.Top:
            case Types.Bottom:
                {
                    GameManager.Hp += item.stateValue;
                    Debug.Log("스탯이 적용되었다. Equipment");
                }
                break;
            case Types.Shoose:
                {
                    GameManager.Speed += item.stateValue;
                    Debug.Log("스탯이 적용되었다. Equipment");
                }
                break;
            default:
                break;
        }
    }

    // 소모성 템 & 스탯은 1종류의 스탯에 영향을 줄 수 있다.
    public static void TakeState(Useable item)
    {
        switch (item.GetComponent<Useable>().EeffectType)
        {
            case EffectType.Hp:
                GameManager.Hp += item.stateValue;
                break;
            case EffectType.Defense:
                GameManager.defense += item.stateValue;
                break;
            case EffectType.Attack:
                GameManager.attack += item.stateValue;
                break;
            default:
                break;
        }
    }

    public static void TakeState(ScriptableObjItem playerStateDatas)
    {
        switch (playerStateDatas.Item.E_effectType)
        {
            case EffectType.Hp:
                GameManager.Hp += playerStateDatas.Item.stateValue;
                break;
            case EffectType.Defense:
                GameManager.defense += playerStateDatas.Item.stateValue;
                break;
            case EffectType.Attack:
                GameManager.attack += playerStateDatas.Item.stateValue;
                break;
            default:
                break;
        }
    }

    public static void TakeAwayState(Weapon item)
    {
        if (item.GetComponent<Weapon>().E_type == Types.Weapon)
        {
            Debug.Log("아이템이 해제되었다. Weapon");
            GameManager.Attack -= item.stateValue;
        }
    }

    public static void TakeAwayState(Equipment item)
    {
        if (item.GetComponent<Equipment>().E_type != Types.Weapon)
        {
            Debug.Log("아이템이 해제되었다. Equipment");
            GameManager.Hp -= item.stateValue;
        }
    }

    //public static void InitGameManager(uint energy,uint coin,int hp,int level,float exp,float speed,int defense,int attack, float BuffRecovery)
    //{
    //    Energy = energy;
    //    Coin = coin;
    //    Hp = hp;
    //    Level = level;
    //    Exp = exp;
    //    Speed = speed;
    //    Defense = defense;
    //    Attack = attack;
    //}
        
}