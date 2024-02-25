using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ScriptableObjActorInfo inputPlayerData;

    private Monsters mon;

    public uint coin; // 재화
    public int level; // 레벨
    public float exp = 0; // 경험치
    public int hp; //  HP
    public int defense; // 방어력
    public int attack; // 공격력
    public float speed;
    public AudioClip walkSound;
    public bool isWalkSound = false;


    public SpawnManager spawnManger;

    public Vector2 vec = Vector2.zero;
    private Animator anim;
    public SpriteRenderer spriter;
    Rigidbody2D rb;

    IEnumerator DelaySound()
    {

        while (true)
        {
            if (isWalkSound)
            {
                yield return new WaitForSeconds(0.2f);
                isWalkSound = false;
            }
            yield return null;
        }
    }




    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mon = GetComponent<Monsters>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        StartCoroutine(DelaySound());
        //spriter[0] = GetComponent<SpriteRenderer>();        
    }

    public void PlayerAttackToEnemy()
    {
        mon.hp -= 10;
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        Debug.Log("파괴 ");
    //        collision.GetComponent<Monsters>().monsterData.hp -= collision.GetComponent<weapon>().Sword.ItemData.attack;


    //        if (collision.GetComponent<Monsters>().monsterData.hp == 0)
    //        {
    //            Destroy(collision.gameObject);
    //        }

    //        //if (collision.GetComponent<MonsterManager>().monHp == 0)
    //        //    Destroy(collision.gameObject);
    //    }
    //}




    // Update is called once per frame
    void Update()
    {
        //float localX = 0f;

        Attack();

        vec = new Vector2(0, 0);
        anim.SetBool("isWalk", false);
        if (Input.GetKey(KeyCode.W))
            vec += new Vector2(0, 1);

        if (Input.GetKey(KeyCode.S))
            vec += new Vector2(0, -1);

        if (Input.GetKey(KeyCode.A))
            vec += new Vector2(-1, 0);

        if (Input.GetKey(KeyCode.D))
            vec += new Vector2(1, 0);


        if (vec != Vector2.zero)
        {
            anim.SetBool("isWalk", true);
            if (isWalkSound == false)
            {
                SoundMgr.instance.Play(walkSound, transform);
                isWalkSound = true;
            }
        }

        vec = vec.normalized * speed;
        rb.velocity = vec;

    }

    public void Attack()
    {
        anim.SetBool("isAttack", true);
    }

    private void LateUpdate()
    {
        if (vec.x != 0)
        {
            spriter.flipX = vec.x < 0;

        }
    }

    public void Init(ScriptableObjActorInfo playerData)
    {
        level = playerData.level;
        exp = playerData.exp;
        hp = playerData.hp;
        defense = playerData.defense;
        attack = playerData.attack;
        speed = playerData.speed;


    }
}