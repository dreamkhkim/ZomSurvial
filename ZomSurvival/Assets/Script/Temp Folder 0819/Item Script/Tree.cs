using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
//using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Tree : Weapon
{
    // Tree : ����� delayTime���� ���� �������� ������ ���� �߻�ü

    [SerializeField]
    public GameObject appleprefeb;  // ������ ������(����)
    public float delayTime = 0.5f;
    public AudioClip treeSound;
    public bool treeSoundcolldown;


    public IEnumerator MakeApple()  
    {
             
        while (true)
        {
            float randRange = Random.Range(0, 50f);              
            Quaternion randZ = Quaternion.Euler(0, 0, randRange);       // ������ �������� ����
            Instantiate(appleprefeb, transform.position, randZ);
            if (treeSoundcolldown == false)
            {
                SoundMgr.instance.Play(treeSound, transform);
                treeSoundcolldown = true;
            }
            yield return new WaitForSeconds(delayTime);
        }
    }

    public IEnumerator DelayTreeSound()
    {
        while (true)
        {
            if (treeSoundcolldown)
            {
                yield return new WaitForSeconds(0.3f);
                treeSoundcolldown = false;
            }
            yield return null;
        }
    }


    void Start()
    {
        StartCoroutine(MakeApple());
        StartCoroutine(DelayTreeSound());
       
    }


    private void Update()
    {
        
    }
}
