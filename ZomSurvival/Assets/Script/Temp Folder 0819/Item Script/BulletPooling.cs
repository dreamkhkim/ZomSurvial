using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


public class BulletPooling : MonoBehaviour
{
    public int initCount = 10;

    public static BulletPooling Instance;   
    //������Ʈ�� �����ϴ� � �ڵ�� ������ �����ؾ��ϴ� �̱��� ������ ���.

    [SerializeField]
    private GameObject poolingObjPrefab;
    //������ ������Ʈ�� ������. �����ص� ������Ʈ�� �� �����༭ ������, ���� �����ؼ� �ֱ� ����.

    Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();
    //ť�� �̿��� ������ �Ѿ� ������Ʈ ����. 

    private void Initialize(int initCount)  //�ʱ�ȭ ���� ���� ���� CreateNewObject �Լ��� ���� �� �Ѿ� ������Ʈ�� ť�� �־���.
    {
        for(int i = 0; i < initCount; i++) 
        {
            poolingObjectQueue.Enqueue(CreateNewBullet()); 
        }
    }

    private Bullet CreateNewBullet()        //�� ���ӿ�����Ʈ�� �����, ��Ȱ���ؼ� ������
    {
        Bullet newObj = Instantiate(poolingObjPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Bullet GetObject()    //������ƮǮ�� �������ִ� ������Ʈ�� ��û�ڿ��� �ִ� ����.
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
        else //ť �ȿ� �� ������Ʈ�� ������ ������Ʈ�� �����ؼ� ��. 
        {
            var newObj = Instance.CreateNewBullet();
            
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Bullet obj)     //������ ������Ʈ�� ��Ȱ��ȭ �� �� ť�� ������.
    {
        Debug.Log("test");
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }

    private void Awake() //���� ������Ʈ ������ ���� ���� �����. 
    {
        Instance = this; //�̱��� ���Ͽ��� ���� �ν��Ͻ��� �ڽ��� �Ҵ�. 

        Initialize(initCount);  //������Ʈ Ǯ �ʱ�ȭ 
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
}
