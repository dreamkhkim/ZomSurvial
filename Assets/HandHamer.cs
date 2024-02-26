using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHamer : Weapon
{

    [SerializeField]
    public ScriptableObjItem itemInfo;


    public Player player;
    public float rotationSpeed = 90.0f; // 회전 속도 설정
    //public ScriptableObjActorInfo plaeyrAttack;

    float prevValue;//= Input.GetAxis("Horizontal");
    float InputWeapon;// = Input.GetAxis("Horizontal");

    bool isRightRotate = true;

    public SpriteRenderer rotateFlip;


    // Start is called before the first frame update
    void Start()
    {
        rotateFlip = GetComponent<SpriteRenderer>();

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
                Destroy(collision.gameObject);
            }

            //if (collision.GetComponent<MonsterManager>().monHp == 0)
            //    Destroy(collision.gameObject);
        }
    }


    IEnumerator RotateWeapon()
    {

        while (true)
        {
            yield return new WaitForSeconds(2);

            if (isRightRotate == false && InputWeapon > 0)
            {
                //rotateFlip.flipX = true;
                Quaternion targetRotaion = Quaternion.Euler(0, 0, 90); // 0 ~ -90도 까지 회전
                Debug.Log("양수 " + targetRotaion);

                float startTime = 0.0f; // 시작시간
                // 0 ~ 90도 까지 회전 하는 걸리는 시간 
                float duration = Mathf.Abs((targetRotaion.eulerAngles.z - transform.rotation.eulerAngles.z) / rotationSpeed);

                while (startTime <= 0.3f)
                {

                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, startTime);
                    startTime += Time.deltaTime;
                    yield return null;
                }
                //transform.rotation = Quaternion.Euler(0, 0, 0);

            }

            else if (isRightRotate == true && InputWeapon < 0)
            {

                
                Quaternion targetRotaion = Quaternion.Euler(0, 0, -90); // 0 ~ -90도 까지 회전
                Debug.Log("양수 " + targetRotaion);

                float startTime = 0.0f; // 시작시간
                                        // 0 ~ 90도 까지 회전 하는 걸리는 시간 
                float duration = Mathf.Abs((targetRotaion.eulerAngles.z - transform.rotation.eulerAngles.z) / rotationSpeed);

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
            rotateFlip.flipX = false;
            isRightRotate = true;
        }
        else if (InputWeapon > 0)
        {
            rotateFlip.flipX = true;
            isRightRotate = false;
        }

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
