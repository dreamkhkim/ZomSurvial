
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    // 바나나 : 주기적으로 던져진다. 땅에 떨어진 바나나는 플레이어/몬스터에게 일시적으로 바나나 State를 준다 (미끄덩~)

    public float throwPower = 100;   //바나나가 던져지는 힘
    public float throwTime = 3;      //바나나가 날아가는 시간
    public float validTime = 7;      //바나나가 존재하는 시간

    public float bananaTime = 2;     //바나나 state 지속시간


    public SpriteRenderer myRend;

    //충돌처리용 변수
    public Rigidbody2D plRb;                       //바나나에 닿은 플레이어의 rigidbody
    public SpriteRenderer plRend;                  //바나나에 닿은 플레이어의 SpriteRender
    public Vector2 adSpeed = Vector2.one * 100;    //닿으면 빨라질 속도↗
    float curTime;

    


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(validTime); // validtime 이 지나면 삭제.
        Destroy(gameObject);
    }


    private void Update()
    {
       
    }
    IEnumerator SettingPeel()
    {
        Debug.Log("SettingPeel 시작");
        yield return new WaitForSeconds(throwTime);
        Rigidbody2D bananaRb = GetComponent<Rigidbody2D>();
        bananaRb.velocity = Vector2.zero;                   //이동 정지. 그 자리에서 바나나 껍질이 됨.
        myRend = GetComponent<SpriteRenderer>();
        myRend.sprite = Resources.Load<Sprite>("WpnSprites/BananaPeel");
         
    }
    
    IEnumerator SetState()                          
    {
        yield return new WaitForSeconds(bananaTime); // time 이 지나면 상태 원복
  
    }



    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D bananaRb = GetComponent<Rigidbody2D>();
        bananaRb.AddRelativeForce(Vector2.right*throwPower, ForceMode2D.Impulse);  // 생성되면 x방향으로 throwPower만큼 발사됨. 
        Debug.Log("AddForce 확인");
        StartCoroutine(SettingPeel());
        StartCoroutine(Destroy());

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monsters>() != null)
        {
            Debug.Log("Monster가 바나나에 닿았다");
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 beforeVelocity = rb.velocity;                  //기존 속도값 복사해둠.

            float randX = Random.Range(-1f, 1f);
            float randY = Random.Range(-1f, 1f);

            Debug.Log("랜덤 방향 부여");
            Vector2 randVec2 = new Vector2(randX, randY);    //랜덤한 방향으로 adSpeed 만큼 발사하자

            Monsters target = other.GetComponentInParent<Monsters>();
            //target.PauseUpdate();                                   // 닿은 몬스터의 업데이트(플레이어 추적)를 멈춤.
            rb.AddForce(randVec2 * adSpeed, ForceMode2D.Impulse);   // 아무방향으로 던짐.
            //target.ResumeUpdate();                                  // 몬스터의 추적 재개



            StartCoroutine (SetState());        //validTime 이 끝나면 원래의 velocity를 돌려준다.
            rb.velocity = beforeVelocity;
            
        }
    }

}
