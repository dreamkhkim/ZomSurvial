using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
   
    public float rotationSpeed = 90.0f; // 회전 속도 설정
    float prevValue;//= Input.GetAxis("Horizontal");
    float InputWeapon;// = Input.GetAxis("Horizontal");

    bool isRightRotate = true;


    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(RotateWeapon());

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
                float duration = Mathf.Abs((targetRotaion.eulerAngles.z - transform.rotation.eulerAngles.z ) / rotationSpeed);

                while (startTime <= 0.8f)
                {

                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, startTime);
                    startTime += Time.deltaTime;
                    yield return null;
                }
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }

            else if (isRightRotate == false &&InputWeapon < 0)
            {
                
                Quaternion targetRotaion = Quaternion.Euler(0, 0, 90); // 0 ~ -90도 까지 회전
                Debug.Log("양수 " + targetRotaion);

                float startTime = 0.0f; // 시작시간
                                        // 0 ~ 90도 까지 회전 하는 걸리는 시간 
                float duration = Mathf.Abs((targetRotaion.eulerAngles.z - transform.rotation.eulerAngles.z) / rotationSpeed);

                while (startTime <= 0.8f)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, startTime);
                    startTime += Time.deltaTime;
                    yield return null;
                }

                transform.rotation = Quaternion.Euler(0, 0, 0);

            }

            
        }

    }



    // Update is called once per frame
    void Update()
    {
        InputWeapon = Input.GetAxis("Horizontal");


        if (InputWeapon < 0)
        {
            isRightRotate = false;
        }
        else
            isRightRotate = true;
        

        if(InputWeapon == 0)
        {
            isRightRotate = true;
            InputWeapon = prevValue;
        }
        else
        {
            prevValue = InputWeapon;
        }
    }
}
