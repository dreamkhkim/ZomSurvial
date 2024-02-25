using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField]
    public GameObject bananaprefeb;  // 던져질 프리팹(바나나)
    public float coolTime = 7;      //바나나를 던지는 쿨타임 (Bananapeel의 validTime과 동일하게 설정함)

    public IEnumerator BananaSummon()
    {
        while (true)
        {
            float randRange = Random.Range(0, 360f);
            Quaternion randZ = Quaternion.Euler(0, 0, randRange);       // 랜덤한 생성각도 지정
            Instantiate(bananaprefeb, transform.position, randZ);
            yield return new WaitForSeconds(coolTime);
        }
    }



    void Start()
    {
        StartCoroutine(BananaSummon());
    }
}
