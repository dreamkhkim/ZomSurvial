using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if (BattleMgr.player != null)
        {
            this.transform.position = new Vector3(BattleMgr.player.transform.position.x, BattleMgr.player.transform.position.y,-300);
        }
    }
}
