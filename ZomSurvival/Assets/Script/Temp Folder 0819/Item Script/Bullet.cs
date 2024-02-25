using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public int bulletDmg = 7;        // �Ѿ��� ���ط� 
    public int bulletSpeed = 3;      // �Ѿ��� �ӵ�
    public int distance = 10;        // �Ѿ��� �Ÿ�
    public int time = 5;             // �Ѿ� ��ȿ�ð�
    public Rigidbody2D rb;
    public Quaternion bulletTf;



    

    private void OnEnable()
    {
        bulletTf = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        //GetComponent<Rigidbody2D>().velocity = Vector3.right * distance;
        //Invoke("ReturnBullet", time);
        StartCoroutine(ReturnCo());
    }

    IEnumerator ReturnCo()
    {
        yield return new WaitForSeconds(time);
        ReturnBullet();
    }

    private void ReturnBullet()
    {
        BulletPooling.ReturnObject(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("������ �����! (hp: -7)");
            other.GetComponent<Monsters>().hp -= bulletDmg;
            if (other.GetComponent<Monsters>().hp <= 0)
            {
                Destroy(other.gameObject);
            }
            BulletPooling.ReturnObject(this);
        }
    }
}
