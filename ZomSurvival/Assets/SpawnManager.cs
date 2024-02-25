using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy; // 적 종류


    
    
    public Transform[] spawnPoint;
    
    public Player player;
    

    public float maxSpawnDelay;
    public float maxSpawnDelay2;
    public float curDelay;



    public float curDelay2;

    float secTime;
    float circleSpawnTime;
    int min;

    private GameObject enemys;
    [SerializeField]
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    //적 물려왔을 때 뜨는 문구들
    public LoopType looptype;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
        text.DOFade(0.0f, 1).SetLoops(-1, looptype);

    }


    void SpawnEnemy()
    {
        int random = Random.Range(0, 2);
        
        if (enemy != null)
        {

            Vector3 randomPoint = new Vector3(Random.Range(-0.9f, 1.5f), Random.Range(-0.9f, 1.5f), 0);
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(randomPoint);
            spawnPosition.z = 0; // Z 축은 0으로 고정

            GameObject newEnemy = Instantiate(enemy[random], spawnPosition, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }
    }



    //좀비들 갑자기 물리는 함
    void EnemyCircle()
    {
        if (enemy != null)
        {
            Debug.Log("10초 경과 중간 몬스터 생성시작 ");

            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Vector3 enemyDistance = new Vector3(Random.Range(-15.0f, 20.0f), Random.Range(-13.0f, 23.0f), 0);
                Vector3 enemyGetPosition = spawnPoint[i].position + enemyDistance;
            
                GameObject newEnemy = Instantiate(enemy[1], enemyGetPosition, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
            }

        }

    }




    public void Clear()
    {

        if (player.hp <= 0)
        {
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                Destroy(spawnedEnemies[i]);
            }
            spawnedEnemies.Clear();

        }
    }

    // Update is called once per frame
    void Update()
    {
        secTime += Time.deltaTime;
        circleSpawnTime += Time.deltaTime;
        //timeText.text = string.Format("{0:D2}:{1:D2}", min, (int)secTime);

        if (secTime > 59)
        {
            secTime = 0;
            min++;
        }
        curDelay += Time.deltaTime;
        curDelay2 += Time.deltaTime;


        if (curDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.2f, 2f);
            curDelay = 0;
        }


        if(circleSpawnTime >= 53)
        {
            text.gameObject.SetActive(true);
        }

        
        if (circleSpawnTime >= 58)
        {
            text.gameObject.SetActive(false);
            for (int i = 0; i < 12; i++)
            {
                EnemyCircle();
            }

            circleSpawnTime = 0;

        }

       
      

    }
}
