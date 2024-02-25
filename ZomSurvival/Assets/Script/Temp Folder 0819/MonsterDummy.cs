using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDummy : MonoBehaviour
{
    public int hp;
    public float speed;             // 몬스터의 이동속도
    public Rigidbody2D target;      // 몬스터의 타겟(플레이어)
    public bool isDead = false;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Die()
    {
        Debug.Log("나를 삭제한다!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon")
        {
            Debug.Log("Weapon 태그와 충돌");
            Die();
        }
    }


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() // Fixed Tiemstep 설정된 간격으로 호출. (RIgid 조정에 사용됨)
    {
        //몬스터가 플레이어를 추적하게 만듦.
        Vector2 dirVec = target.position - rigid.position;  //위치 차이 = 타겟 위치 - 나의 위치 
        Vector2 nextVec = dirVec.normalized * speed;        //*Time.fixedDeltaTime 까지 하면 프레임으로 인해 달라지지않음.
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;                                 //물리적인 속도가 이동에 영향을 주지않기 위해 제거.
    }



}
