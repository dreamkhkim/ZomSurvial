using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CarrotMisile : Weapon
{


    [SerializeField]
    public ScriptableObjItem itemInfo;


    // �̵� ���� ����
    public int carrotDmg = 20;
    public float rotateSpeed;        // ȸ���ӵ�
    public float moveSpeed;         // �̵��ӵ�
    float move_x_rate;
    float move_y_rate;
    public float dmgDelay = 2f;      // ���ظ� �ִ� ����

    float sectime = 0f;

    // Start is called before the first frame update
    void Start()
    {

        move_x_rate = Random.Range(-1.0f, 1.0f);
        move_y_rate = Random.Range(-1.0f, 1.0f);

        while (Mathf.Abs(move_x_rate) < 0.3f)
        {
            move_x_rate = Random.Range(-1.0f, 1.0f);
        }

        while (Mathf.Abs(move_y_rate) < 0.3f)
        {
            move_y_rate = Random.Range(-1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sectime += Time.deltaTime;
        transform.Rotate(Vector3.forward * rotateSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * move_x_rate, Space.World);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * move_y_rate, Space.World);

        // ī�޶� ����� �ʵ��� ���� ����
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        if (position.x < 0f)
        {
            position.x = 0f;
            move_x_rate = Random.Range(0.3f, 1.0f);
        }
        if (position.y < 0f)
        {
            position.y = 0f;
            move_y_rate = Random.Range(0.3f, 1.0f);
        }
        if (position.x > 1f)
        {
            position.x = 1f;
            move_x_rate = Random.Range(-1.0f, -0.3f);
        }
        if (position.y > 1f)
        {
            position.y = 1f;
            move_y_rate = Random.Range(-1.0f, -0.3f);
        }

        if(sectime > 5f)
        {
            Destroy(gameObject);
        }

        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    IEnumerator DmgDelay()
    {
        yield return new WaitForSeconds(dmgDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("���Ͱ� ��ٿ� ������� �Ծ���! (hp : -20)");
            other.GetComponent<Monsters>().hp -= carrotDmg;
            StartCoroutine(DmgDelay());

            if (other.GetComponent<Monsters>().hp <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }

}