using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    public float exp = 50f;


    public int particleDelay = 2;
    public GameObject expParticle;

    IEnumerator DestroyDelay()
    {
        // healParticle.Play(); //��ƼŬ ���� 

        expParticle.SetActive(true);
        yield return new WaitForSeconds(particleDelay); //1�ʵ� ����
        Destroy(gameObject);
    }
    private void Start()
    {

        expParticle = GetComponentInChildren<ParticleSystem>(true).gameObject;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().exp += exp;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            StartCoroutine(DestroyDelay());

        }

    }
}
