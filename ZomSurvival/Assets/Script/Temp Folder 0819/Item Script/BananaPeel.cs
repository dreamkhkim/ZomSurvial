
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    // �ٳ��� : �ֱ������� ��������. ���� ������ �ٳ����� �÷��̾�/���Ϳ��� �Ͻ������� �ٳ��� State�� �ش� (�̲���~)

    public float throwPower = 100;   //�ٳ����� �������� ��
    public float throwTime = 3;      //�ٳ����� ���ư��� �ð�
    public float validTime = 7;      //�ٳ����� �����ϴ� �ð�

    public float bananaTime = 2;     //�ٳ��� state ���ӽð�


    public SpriteRenderer myRend;

    //�浹ó���� ����
    public Rigidbody2D plRb;                       //�ٳ����� ���� �÷��̾��� rigidbody
    public SpriteRenderer plRend;                  //�ٳ����� ���� �÷��̾��� SpriteRender
    public Vector2 adSpeed = Vector2.one * 100;    //������ ������ �ӵ���
    float curTime;

    


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(validTime); // validtime �� ������ ����.
        Destroy(gameObject);
    }


    private void Update()
    {
       
    }
    IEnumerator SettingPeel()
    {
        Debug.Log("SettingPeel ����");
        yield return new WaitForSeconds(throwTime);
        Rigidbody2D bananaRb = GetComponent<Rigidbody2D>();
        bananaRb.velocity = Vector2.zero;                   //�̵� ����. �� �ڸ����� �ٳ��� ������ ��.
        myRend = GetComponent<SpriteRenderer>();
        myRend.sprite = Resources.Load<Sprite>("WpnSprites/BananaPeel");
         
    }
    
    IEnumerator SetState()                          
    {
        yield return new WaitForSeconds(bananaTime); // time �� ������ ���� ����
  
    }



    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D bananaRb = GetComponent<Rigidbody2D>();
        bananaRb.AddRelativeForce(Vector2.right*throwPower, ForceMode2D.Impulse);  // �����Ǹ� x�������� throwPower��ŭ �߻��. 
        Debug.Log("AddForce Ȯ��");
        StartCoroutine(SettingPeel());
        StartCoroutine(Destroy());

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monsters>() != null)
        {
            Debug.Log("Monster�� �ٳ����� ��Ҵ�");
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 beforeVelocity = rb.velocity;                  //���� �ӵ��� �����ص�.

            float randX = Random.Range(-1f, 1f);
            float randY = Random.Range(-1f, 1f);

            Debug.Log("���� ���� �ο�");
            Vector2 randVec2 = new Vector2(randX, randY);    //������ �������� adSpeed ��ŭ �߻�����

            Monsters target = other.GetComponentInParent<Monsters>();
            //target.PauseUpdate();                                   // ���� ������ ������Ʈ(�÷��̾� ����)�� ����.
            rb.AddForce(randVec2 * adSpeed, ForceMode2D.Impulse);   // �ƹ��������� ����.
            //target.ResumeUpdate();                                  // ������ ���� �簳



            StartCoroutine (SetState());        //validTime �� ������ ������ velocity�� �����ش�.
            rb.velocity = beforeVelocity;
            
        }
    }

}
