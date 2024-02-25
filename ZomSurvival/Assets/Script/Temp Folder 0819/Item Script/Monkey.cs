using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField]
    public GameObject bananaprefeb;  // ������ ������(�ٳ���)
    public float coolTime = 7;      //�ٳ����� ������ ��Ÿ�� (Bananapeel�� validTime�� �����ϰ� ������)

    public IEnumerator BananaSummon()
    {
        while (true)
        {
            float randRange = Random.Range(0, 360f);
            Quaternion randZ = Quaternion.Euler(0, 0, randRange);       // ������ �������� ����
            Instantiate(bananaprefeb, transform.position, randZ);
            yield return new WaitForSeconds(coolTime);
        }
    }



    void Start()
    {
        StartCoroutine(BananaSummon());
    }
}
