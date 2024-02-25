using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float angle;

    public Vector3 target;
    public Vector3 mouse;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;


        angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = rotation;


    }
}
