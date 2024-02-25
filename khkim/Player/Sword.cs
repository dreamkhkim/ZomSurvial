using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public Player player;
    public Monsters mon;
    
    public float rotationSpeed = 90.0f; // 회전 속도 설정
    //public ScriptableObjActorInfo plaeyrAttack;

    float prevValue;//= Input.GetAxis("Horizontal");
    float InputWeapon;// = Input.GetAxis("Horizontal");

    bool isRightRotate = true;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateWeapon());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("파괴 ");
            collision.GetComponent<Monsters>().hp -= player.attack;


            if (collision.GetComponent<Monsters>().hp <= 0)
            {
                Debug.Log("exp 획득 ");
                collision.GetComponent<Monsters>().DropItme();
                Destroy(collision.gameObject);
            }

        }
    }


    IEnumerator RotateWeapon()
    {

        while (true)
        {
            yield return new WaitForSeconds(2);

            if (isRightRotate)
            {
                Quaternion targetRotaion = Quaternion.Euler(0, 0, -90); // 0 ~ -90도 까지 회전
                Debug.Log("양수 " + targetRotaion);

                float startTime = 0.0f; // 시작시간
                // 0 ~ 90도 까지 회전 하는 걸리는 시간 
 
                while (startTime <= 0.3f)
                {

                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, startTime);
                    startTime += Time.deltaTime;
                    yield return null;
                }


            }

            else if (isRightRotate == false && InputWeapon < 0)
            {

                Quaternion targetRotaion = Quaternion.Euler(0, 0, 90); // 0 ~ -90도 까지 회전
                Debug.Log("양수 " + targetRotaion);

                float startTime = 0.0f; // 시작시간
                                        // 0 ~ 90도 까지 회전 하는 걸리는 시간 

                while (startTime <= 0.3f)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, startTime);
                    startTime += Time.deltaTime;
                    yield return null;
                }

            }

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }



    // Update is called once per frame
    void Update()
    {
        
        InputWeapon = Input.GetAxis("Horizontal");


        if (transform.rotation.z == 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
            gameObject.GetComponent<BoxCollider2D>().enabled = true;


        if (InputWeapon < 0)
        {
            isRightRotate = false;
        }
        else if (InputWeapon > 0)
            isRightRotate = true;


        if (InputWeapon == 0)
        {
            //isRightRotate = true;
            InputWeapon = prevValue;
        }
        else
        {
            prevValue = InputWeapon;
        }
    }
}
