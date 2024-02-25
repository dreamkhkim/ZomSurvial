using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruits : MonoBehaviour
{
    public int fruitDmg = 10;      // 과일 데미지
    public int throwSpeed = 20;   // 과일 던져지는 속도
    public int time = 3;          // 과일 소멸처리 시간
    public Rigidbody2D rb;
    public AudioClip fruitSound;
    public bool fruitSoundCoolTime;
            // 과일이 담긴 스프라이트 배열



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
    void Start() // 랜덤한 과일 
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
            yield return new WaitForSeconds(time); // time 이 지나면 삭제.
            Destroy(gameObject);            
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("과일을 맞췄다! 과즙이 팡! (hp: -10)");            
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
