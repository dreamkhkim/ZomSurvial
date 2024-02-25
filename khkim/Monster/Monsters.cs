using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public ScriptableObjActorInfo monsterData;


    private Transform target;
    private float player;
    private Rigidbody2D rb;

    private Animator anim;
    private bool isDamaging = false;

    public SpriteRenderer spriteRender;
    public SpawnManager spawnManger;

    public GameObject[] dropItemArr;
    public AudioClip monsterSound;
    public AudioClip monDeadSound;
    public bool monsterIsWalk = false;





    //public uint coin; // 재화
    public int level; // 레벨
    public float exp; // 경험치
    public int hp; //  HP
    //public int defense; // 방어력
    public int attack; // 공격력
    public float speed;
    //public float buffRecovery; // 회복 아이템 버프 수치


    IEnumerator DamageCharacter(Player player, int damage, int interval)
    {
        while (true)
        {
            player.hp -= damage;
            if (player.hp <= 0)
            {
                //Destroy(player.gameObject);
                StopCoroutine(DamageCharacter(player, attack, 3));
                Time.timeScale = 0f;
                PopupMgr.Instance().OpenPopup("GUI_Result");
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
        }

    }
    IEnumerator DelayMonsterSound()
    {

        while (true)
        {
            if (monsterIsWalk)
            {
                yield return new WaitForSeconds(3);
                monsterIsWalk = false;
            }
            yield return null;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && !isDamaging)
        {
            

            Debug.Log("플레이어 부딪힘 ");
            Player player = collision.gameObject.GetComponent<Player>();

            StartCoroutine(DamageCharacter(player, monsterData.attack, 3));
            if (player.hp <= 0)
            {
                player.spawnManger.Clear();
            }
            isDamaging = true;

        }

    }







    // Start is called before the first frame update
    void Start()
    {
        Init(monsterData);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DelayMonsterSound());
        player = 0f;


    }


    //몬스터가 죽으면 아이템 떨구는
    public void DropItme()
    {
        int randNum = Random.Range(0, 3);           // 배열 크기 고민중 : exp * 3, exp 2배 *1 , 회복, 공격력, 이동속도up , 무기active 
        Debug.Log(randNum);
        if (hp <= 0)
        {
            SoundMgr.instance.Play(monDeadSound, transform);
            if (dropItemArr != null)
            {
                Instantiate(dropItemArr[randNum], transform.position, Quaternion.identity); //dropItemArr 안의 랜덤 아이템 생성
                Destroy(gameObject); 
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

        DropItme();
        

        anim.SetBool("isWalk", true);
        rb.velocity = Vector3.zero;

        Vector3 dir = target.position - transform.position;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (monsterIsWalk == false)
        {
            monsterIsWalk = true;
            SoundMgr.instance.Play(monsterSound, transform);
        }
    }


    private void LateUpdate()
    {
        spriteRender.flipX = target.position.x < rb.position.x;
    }

    void Init(ScriptableObjActorInfo monsterData)
    {
        level = monsterData.level;
        exp = monsterData.exp;
        hp = monsterData.hp; //  HP
        //defense = monsterData.defense; // 방어
        attack = monsterData.attack; // 공격
        speed = monsterData.speed;
        //buffRecovery = monsterData.buffRecovery;
    }
}
