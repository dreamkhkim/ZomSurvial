using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CarrotItem : MonoBehaviour
{
    public GameObject carrotPrefeb;
    public int particleDelay = 1;
    public GameObject[] carrots;

    float sectime = 0f;


    IEnumerator MakeCarrot()
    {
        int number = 4;
        while (number > 0)
        {
            Instantiate(carrotPrefeb, transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
            number--;
        }
       
        yield return new WaitForSeconds(particleDelay); //1초뒤 삭제
        Destroy(gameObject);
    }


    private void Start()
    {
        carrots = GameObject.FindGameObjectsWithTag("Carrot");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
           
        if (collision.gameObject.tag == "Player")
        {

            if (carrots.Length > 5)
            {
                Debug.Log("당근 최대치 도달. 생성실패");
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(MakeCarrot());
                //Instantiate(carrotPrefeb, transform.position, transform.rotation);
                Debug.Log("당근미사일 생성");
                Destroy(gameObject);

            }
            Debug.Log(carrots.Length);

        }
        
    }
}