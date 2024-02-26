using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDummy : MonoBehaviour
{
    public int hp;
    public float speed;             // ������ �̵��ӵ�
    public Rigidbody2D target;      // ������ Ÿ��(�÷��̾�)
    public bool isDead = false;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Die()
    {
        Debug.Log("���� �����Ѵ�!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon")
        {
            Debug.Log("Weapon �±׿� �浹");
            Die();
        }
    }


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() // Fixed Tiemstep ������ �������� ȣ��. (RIgid ������ ����)
    {
        //���Ͱ� �÷��̾ �����ϰ� ����.
        Vector2 dirVec = target.position - rigid.position;  //��ġ ���� = Ÿ�� ��ġ - ���� ��ġ 
        Vector2 nextVec = dirVec.normalized * speed;        //*Time.fixedDeltaTime ���� �ϸ� ���������� ���� �޶���������.
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;                                 //�������� �ӵ��� �̵��� ������ �����ʱ� ���� ����.
    }



}
