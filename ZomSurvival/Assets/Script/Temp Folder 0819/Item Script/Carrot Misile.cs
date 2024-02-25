using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CarrotMisile : Weapon
{


    [SerializeField]
    public ScriptableObjItem itemInfo;


    // 이동 관련 변수
    public int carrotDmg = 20;
    public float rotateSpeed;        // 회전속도
    public float moveSpeed;         // 이동속도
    float move_x_rate;
    float move_y_rate;
    public float dmgDelay = 2f;      // 피해를 주는 간격

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

        // 카메라를 벗어나지 않도록 범위 제한
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
            Debug.Log("몬스터가 당근에 관통상을 입었다! (hp : -20)");
            other.GetComponent<Monsters>().hp -= carrotDmg;
            StartCoroutine(DmgDelay());

            if (other.GetComponent<Monsters>().hp <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }

}