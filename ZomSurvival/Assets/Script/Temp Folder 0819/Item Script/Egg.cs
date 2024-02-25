using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Egg : Weapon
{
    // Egg : �÷��̾ �Ѿƴٴϸ�, ��������̸�(������ ����) ��Ÿ�Ӹ��� �ڽ��� ��ġ�� ��ġ.

    [SerializeField]
    public GameObject friedEggprefeb;     // ��ġ�� �ٴ�(���������)
    public float delayTime = 3f;               // ��ġ ��Ÿ��
    public Transform player;              // ����ٴ� �÷��̾��� ��ġ
    public float eggSpeed = 2f;                // Egg�� �̵��ӵ�
    public float distance = 5;                // �������� �Ÿ�

    Rigidbody2D rigid;


    public IEnumerator PutDownEgg()
    {

        while (true)
        {
            float randRange = Random.Range(0f, 360f);               
            Quaternion randZ = Quaternion.Euler(0, 0, randRange);   //�������� ȸ���� ��������� ����
           
            Instantiate(friedEggprefeb, transform.position, randZ);

            yield return new WaitForSeconds(delayTime);
        }
    }

    void Start()
    {
        StartCoroutine(PutDownEgg());
        rigid = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()      //�ް��� �÷��̾ �Ѿƿ�(��ġ ��ó��)
    {
        player = GameObject.FindObjectOfType<Player>().transform;
        Vector2 direction = player.position - transform.position;  //���� = �÷��̾� ��ġ - ��(���)�� ��ġ
        Vector2 nextVec = direction.normalized * eggSpeed;         //nextVec�� �븻������ �� ���� �Է�. (*Time.fixedDeltaTime ���� �ϸ� ���������� ���� �޶���������)
        rigid.MovePosition(rigid.position + nextVec);              
        //rigid.velocity = Vector2.zero;                             //�������� �ӵ��� �̵��� ������ �����ʱ� ���� ����
        // ���� : �÷��̾�� �Ÿ�(distance) �� �ΰ� ������� �ϰ�����. (�������� �ʰ�) 
    }
}
