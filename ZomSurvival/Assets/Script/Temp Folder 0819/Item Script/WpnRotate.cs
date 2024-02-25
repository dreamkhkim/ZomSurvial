using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnRotate : MonoBehaviour
{
    public float moveSpeed; // 회전속도 
    public float movement; // 회전방향 
    public Vector3 axis; // 회전축(플레이어 위치)
    public GameObject pl;

    private void Start()
    {
        pl = GameObject.Find("Player");
       
    }

    void Update()
    {
        axis = pl.transform.position;
    }

    void FixedUpdate()
    {
        transform.RotateAround(axis, Vector3.forward, movement * moveSpeed);     //*Time.fixedDeltaTime 유무의 차이?
    }
}
