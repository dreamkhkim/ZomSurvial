using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    public static BattleMgr battleMgr = null;
    public static GameObject player = null;
    [HideInInspector]
    public Player makeComplitePlayer = null;
    public static int cashPlayerHp;
    public ItemDataTable playerStateSaveDataList = null;
    public ScriptableObjActorInfo PlayerInfo = null; // Actor�� Info

    public const int maxMonsterCount = 0;

    public GameObject battlePopup = null;

    [HideInInspector]
    public static float playTime = 0;
    float cumulativeTimeCoin = 0;
    float cumulativeTimeExp = 0;
    [HideInInspector]
    public uint getCoin = 0;
    //[HideInInspector]
    //public float getExp = 0;

    Queue<int> needExpArr = null;
    public float maxExpOfPlayer;
    private void Start()
    {
        GameManager.userStateType = UserStateType.Battle;
        GameObject battleObj = GameObject.FindGameObjectWithTag("BattleManager");
        if (battleObj == null) { Debug.Log("battleManager null"); }
        else
        {
            Time.timeScale = 1;
            battleMgr = battleObj.GetComponent<BattleMgr>();
            playTime += Time.time; // 플레이 시간을 잴 시작 시간
            if (battleMgr != null)
            {
                player = CreateInstance("Player", ActorType.Player, 0).gameObject; //플레이어 생성
                Player playerPtr = player.GetComponent<Player>();

                if (playerPtr == null)
                {
                    Debug.Log("player 캐싱 실패");
                }

                playerPtr.Init(PlayerInfo); // 플레이어 초기화
                Debug.Log("플레이어 초기화 되었음");
                for (int i = 0; i < playerStateSaveDataList.table.Count; i++)
                {
                    if (playerStateSaveDataList.table[i].Item.isUsed == true)
                    {
                        GameManager.TakeState(playerStateSaveDataList.table[i]); // 스탯 데이터 추가
                        Debug.Log("State 데이터 추가 되었음");
                    }
                }

                // 마지막 데이터 가공
                playerPtr.hp += GameManager.Hp;
                playerPtr.defense += GameManager.Defense;
                playerPtr.attack += GameManager.Attack;
                playerPtr.speed += GameManager.Speed;

                makeComplitePlayer = playerPtr;
                cashPlayerHp = playerPtr.hp;
            }
        }

        needExpArr = new Queue<int>(20);
        // 경험치 대충 초기화

        for(int i = 1; i <= 20; i++)
        {
            needExpArr.Enqueue(100 * i);
        }

        ////랜뽑 해야댐 - 시현이가
        //pickItemDataTable = GetInGameItemTable(inGameItemTable); //새로 생성해서 줬음
        //SetItemData(); //실제 객체화
        //Inventory.Instance().InGameItems = GetInGameItem(inGameItems);
    }

    private void Update()
    {
        if (UserStateType.Battle == GameManager.userStateType)
        {
            if (Time.timeScale > 0)
            {
                GetCoin();
                //GetExp(); // 템 먹으면 Exp가 올라가는걸로 변경해야 함.
            }

            if (needExpArr != null && needExpArr.Count > 0 && player != null)
            {
                if (player.GetComponent<Player>().exp >= needExpArr.Peek())
                {
                    Time.timeScale = 0f;
                    LevelUp(player.GetComponent<Player>());

                    PopupMgr.Instance().ActivePopup(battlePopup); // 활성화

                    //if (PopupMgr.Instance().Click && Time.timeScale == 0f)
                    //{
                    //    Time.timeScale = 1f;
                    //}

                }
            }
        }
    }

    public void LevelUp(Player player)
    {
        player.level += 1;
        player.GetComponent<Player>().exp = 0;
        maxExpOfPlayer = needExpArr.Dequeue() + 100;
        player.hp = cashPlayerHp;
    }

    void GetCoin()
    {
        cumulativeTimeCoin += Time.deltaTime;
        if (cumulativeTimeCoin >= 2f)
        {
            getCoin += 1;
            cumulativeTimeCoin = 0f;
        }
    }

    float GetExp()
    {
        //cumulativeTimeExp += Time.deltaTime;
        //if (cumulativeTimeExp >= 10f)
        //{
        //    getExp += 0.1f;
        //    cumulativeTimeExp = 0f;
        //}

        return player.GetComponent<Player>().exp;
    }
    GameObject CreateInstance(string instanceName, ActorType actorType, int index)
    {
        GameObject Instance = null;
        Instance = Instantiate(Resources.Load<GameObject>("Prefab/" + instanceName), Vector3.zero, Quaternion.identity);

        return Instance;
    }
}
