using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : Weapon
{
    public float delayTime = 1;                 // 총알 생성 지연시간
    public GameObject bulletPrefeb = null;      // 발사할 총알
   
    [SerializeField]
    public ScriptableObjItem itemInfo;

    public override void Init(ScriptableObjItem inputData)
    {
        name = inputData.Item.name;
        img = inputData.Item.img;
        level = inputData.Item.level;
        price = inputData.Item.price;
        infomation = inputData.Item.infomation;
        stateValue = inputData.Item.stateValue;
        skillValue = inputData.Item.skillValue;
    }


  
    public IEnumerator BulletSummon()
    {
        while (true)
        {
            if (bulletPrefeb == null)        // 총알 프리펩이 없으면 ObjectPooling 사용
            {
                BulletPooling.GetObject().gameObject.transform.position = transform.position;
                yield return new WaitForSeconds(delayTime);

            }
            else if (bulletPrefeb != null)   // 총알 프리펩이 있으면 Instantiate 사용
            {
                Debug.Log("Instantiate 로 Fire생성");
                Instantiate(bulletPrefeb, transform.position, transform.rotation);                
                yield return new WaitForSeconds(delayTime);
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Init(itemInfo);
        Debug.Log(name);
        Debug.Log(infomation);
        StartCoroutine(BulletSummon());
    }


    void Update()
    {


    }
}
