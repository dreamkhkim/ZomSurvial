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

// ���� �Ŵ����� 2�������� �ȵȴ�.
public class GameManager : MonoBehaviour
{
    public static UserStateType userStateType = UserStateType.Main;

    //player---------------------------------------------------------------------------------//
    static uint energy = 30; // ��Ʋ ����Ʈ
    static uint coin = 1500; // ��ȭ
    static int level = 1; // ����
    static float exp; // ����ġ
    static int hp = 0; //  HP
    static int defense = 0; // ����
    static int attack = 0; // ���ݷ�
    static float speed = 0f;
    static uint battleCoin = 0;
    //static float buff; // ���� ��ġ
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
            Debug.Log("������ ����Ǿ���. Weapon");
            GameManager.Attack += item.stateValue;
        }
    }

    // ����� Ÿ�Կ� ���� �÷��̾��� ���ȿ� ������ �ְԵȴ�.
    public static void TakeState(Equipment item)
    {
        switch (item.GetComponent<Equipment>().E_type)
        {
            case Types.Top:
            case Types.Bottom:
                {
                    GameManager.Hp += item.stateValue;
                    Debug.Log("������ ����Ǿ���. Equipment");
                }
                break;
            case Types.Shoose:
                {
                    GameManager.Speed += item.stateValue;
                    Debug.Log("������ ����Ǿ���. Equipment");
                }
                break;
            default:
                break;
        }
    }

    // �Ҹ� �� & ������ 1������ ���ȿ� ������ �� �� �ִ�.
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
            Debug.Log("�������� �����Ǿ���. Weapon");
            GameManager.Attack -= item.stateValue;
        }
    }

    public static void TakeAwayState(Equipment item)
    {
        if (item.GetComponent<Equipment>().E_type != Types.Weapon)
        {
            Debug.Log("�������� �����Ǿ���. Equipment");
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