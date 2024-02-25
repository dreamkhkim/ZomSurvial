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
       
        yield return new WaitForSeconds(particleDelay); //1�ʵ� ����
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
                Debug.Log("��� �ִ�ġ ����. ��������");
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(MakeCarrot());
                //Instantiate(carrotPrefeb, transform.position, transform.rotation);
                Debug.Log("��ٹ̻��� ����");
                Destroy(gameObject);

            }
            Debug.Log(carrots.Length);

        }
        
    }
}