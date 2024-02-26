using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruits : MonoBehaviour
{
    public int fruitDmg = 10;      // ���� ������
    public int throwSpeed = 20;   // ���� �������� �ӵ�
    public int time = 3;          // ���� �Ҹ�ó�� �ð�
    public Rigidbody2D rb;
    public AudioClip fruitSound;
    public bool fruitSoundCoolTime;
            // ������ ��� ��������Ʈ �迭



    IEnumerator DelayFruitSound()
    {
        while(true)
        {
            if (fruitSoundCoolTime)
            {
                yield return new WaitForSeconds(1);
                fruitSoundCoolTime = false;
            }
            yield return null;
        }
    }




    // Start is called before the first frame update
    void Start() // ������ ���� 
    {
        Sprite[] fruitsAtlas = Resources.LoadAll<Sprite>("WpnSprites/Fruits");
        SpriteRenderer fruitSprite = gameObject.GetComponent<SpriteRenderer>(); ;
        
        int randNum = Random.Range(0, 15);
        fruitSprite.sprite = fruitsAtlas[randNum];
        StartCoroutine(FruitDestroy());
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up * throwSpeed, ForceMode2D.Impulse);
        
    }

    IEnumerator FruitDestroy()
    {
            yield return new WaitForSeconds(time); // time �� ������ ����.
            Destroy(gameObject);            
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("������ �����! ������ ��! (hp: -10)");            
            SoundMgr.instance.Play(fruitSound, transform);
             
          
            other.GetComponent<Monsters>().hp -= fruitDmg;
            if (other.GetComponent<Monsters>().hp <= 0)
            {
                other.GetComponent<Monsters>().DropItme();
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }

}
