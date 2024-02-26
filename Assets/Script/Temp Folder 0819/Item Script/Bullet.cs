using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public int bulletDmg = 7;        // ÃÑ¾ËÀÇ ÇÇÇØ·® 
    public int bulletSpeed = 3;      // ÃÑ¾ËÀÇ ¼Óµµ
    public int distance = 10;        // ÃÑ¾ËÀÇ °Å¸®
    public int time = 5;             // ÃÑ¾Ë À¯È¿½Ã°£
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
            Debug.Log("¹°ÃÑÀ» ¸ÂÃè´Ù! (hp: -7)");
            other.GetComponent<Monsters>().hp -= bulletDmg;
            if (other.GetComponent<Monsters>().hp <= 0)
            {
                Destroy(other.gameObject);
            }
            BulletPooling.ReturnObject(this);
        }
    }
}
