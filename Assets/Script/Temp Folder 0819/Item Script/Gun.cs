using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : Weapon
{
    public float delayTime = 1;                 // �Ѿ� ���� �����ð�
    public GameObject bulletPrefeb = null;      // �߻��� �Ѿ�
   
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
            if (bulletPrefeb == null)        // �Ѿ� �������� ������ ObjectPooling ���
            {
                BulletPooling.GetObject().gameObject.transform.position = transform.position;
                yield return new WaitForSeconds(delayTime);

            }
            else if (bulletPrefeb != null)   // �Ѿ� �������� ������ Instantiate ���
            {
                Debug.Log("Instantiate �� Fire����");
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
