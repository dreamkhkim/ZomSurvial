using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


public class BulletPooling : MonoBehaviour
{
    public int initCount = 10;

    public static BulletPooling Instance;   
    //오브젝트를 생성하는 어떤 코드던 접근이 가능해야하니 싱글톤 패턴을 사용.

    [SerializeField]
    private GameObject poolingObjPrefab;
    //생성할 오브젝트의 프리팹. 생성해둔 오브젝트를 다 꺼내줘서 없을때, 새로 생성해서 주기 위함.

    Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();
    //큐를 이용해 생성된 총알 오브젝트 관리. 

    private void Initialize(int initCount)  //초기화 갯수 값에 따라 CreateNewObject 함수로 만든 새 총알 오브젝트를 큐에 넣어줌.
    {
        for(int i = 0; i < initCount; i++) 
        {
            poolingObjectQueue.Enqueue(CreateNewBullet()); 
        }
    }

    private Bullet CreateNewBullet()        //새 게임오브젝트를 만들고, 비활성해서 돌려줌
    {
        Bullet newObj = Instantiate(poolingObjPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Bullet GetObject()    //오브젝트풀이 가지고있는 오브젝트를 요청자에게 주는 역할.
    {
        if(Instance.poolingObjectQueue.Count > 0)  
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj.gameObject.transform.position = Vector3.zero;
            //obj.gameObject.transform.rotation = Quaternion.identity;
            obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else //큐 안에 줄 오브젝트가 없으면 오브젝트를 생성해서 줌. 
        {
            var newObj = Instance.CreateNewBullet();
            
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Bullet obj)     //빌려준 오브젝트를 비활성화 한 뒤 큐에 수납함.
    {
        Debug.Log("test");
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }

    private void Awake() //게임 오브젝트 생성시 가장 먼저 실행됨. 
    {
        Instance = this; //싱글톤 패턴에서 사용될 인스턴스에 자신을 할당. 

        Initialize(initCount);  //오브젝트 풀 초기화 
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
}
