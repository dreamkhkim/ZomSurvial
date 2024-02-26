using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnRotate : MonoBehaviour
{
    public float moveSpeed; // ȸ���ӵ� 
    public float movement; // ȸ������ 
    public Vector3 axis; // ȸ����(�÷��̾� ��ġ)
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
        transform.RotateAround(axis, Vector3.forward, movement * moveSpeed);     //*Time.fixedDeltaTime ������ ����?
    }
}
