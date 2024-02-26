using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    public int fruitDmg = 5;      // ���� ������
    public int throwSpeed = 10;   // ���� �������� �ӵ�
    public int time = 3;          // ���� �Ҹ�ó�� �ð�
    public Rigidbody2D rb;
            // ������ ��� ��������Ʈ �迭


    // Start is called before the first frame update
    void Start() // ������ ���� 
    {
        Sprite[] fruitsAtlas = Resources.LoadAll<Sprite>("WpnSprites/Fruits");
        SpriteRenderer fruitSprite = gameObject.GetComponent<SpriteRenderer>(); ;
        
        int randNum = Random.Range(0, 15);
        fruitSprite.sprite = fruitsAtlas[randNum];
        StartCoroutine(FruitDestroy());
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up * throwSpeed, ForceMode2D.Impulse);
        
    }

    IEnumerator FruitDestroy()
    {
            yield return new WaitForSeconds(time); // time �� ������ ����.
            Destroy(gameObject);            
    }



}
