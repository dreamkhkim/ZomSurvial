using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriedEgg : MonoBehaviour
{
    public int friedEggDmg = 10;  // ����
    public int time = 5;          // ��������� �Ҹ�ó�� �� �ð�
    public float dmgDelay = 2f;         // �� ���ظ� �ִ� ����

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time); // time �� ������ ����.
        Destroy(gameObject);
    }

    IEnumerator DmgDelay()
    {
        yield return new WaitForSeconds(dmgDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("���Ͱ� �� ������ ����������� ��Ҵ�! ������! (hp : -20)");
            other.GetComponent<Monsters>().hp -= friedEggDmg;
            StartCoroutine(DmgDelay());

            if (other.GetComponent<Monsters>().hp <= 0)
            {
                other.GetComponent<Monsters>().DropItme();
                Destroy(other.gameObject);
            }
        }
    }


}
