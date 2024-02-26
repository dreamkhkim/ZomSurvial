using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int fireDmg = 10;               // ���� ������
    public float validTime = 1f;          // �� �Ҹ�ó�� �� �ð�
    public float dmgDelay = 0.5f;         // �� ���ظ� �ִ� ����
    public AudioClip fireSound;

    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(validTime); // time �� ������ ����.
        Destroy(gameObject);
    }

    IEnumerator DmgDelay()
    {
        yield return new WaitForSeconds(validTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("���Ϳ��� �� ������ ������. �븩�븩! (hp : -10)");
            SoundMgr.instance.Play(fireSound, transform);
            other.GetComponent<Monsters>().hp -= fireDmg;
            StartCoroutine(DmgDelay());

            if (other.GetComponent<Monsters>().hp <= 0)
            {
                other.GetComponent<Monsters>().DropItme();
                Destroy(other.gameObject);
            }
        }
    }
}

 