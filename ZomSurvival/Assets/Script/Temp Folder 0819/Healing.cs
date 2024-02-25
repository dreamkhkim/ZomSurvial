using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public int healing = 30;
    public int particleDelay = 1;
    // public ParticleSystem healParticle;  
    public GameObject healParticle;

    IEnumerator DestroyDelay()
    {
       // healParticle.Play(); //파티클 실행 

        healParticle.SetActive(true);
        yield return new WaitForSeconds(particleDelay); //1초뒤 삭제
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어 회복됨 +30");
            collision.GetComponent<Player>().hp += healing;

            if (collision.GetComponent<Player>().hp > BattleMgr.cashPlayerHp)
            {
                collision.GetComponent<Player>().hp = BattleMgr.cashPlayerHp;
            }

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            StartCoroutine(DestroyDelay());
        }
    }

    private void Start()
    {
        
        healParticle = GetComponentInChildren<ParticleSystem>(true).gameObject;

    }
}
