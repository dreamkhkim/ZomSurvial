using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr
{
    static SceneMgr sceneMgr = null;


    public static SceneMgr Instance()
    {
        if (sceneMgr == null)
        {
            sceneMgr = new SceneMgr();
        }
        return sceneMgr;
    }

    static bool isPause = false;

    public void CallScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public Object Spawn(string prefabName)
    {
        return Resources.Load("" + prefabName);
    }

    void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            isPause = true;
        }
        else
        {
            isPause = false;
        }
    }

    public void CheckPause()
    {
        if (isPause)
        {
            Debug.Log("일시 정지중");
            Time.timeScale = 0.0f;
        }
        else
        {
            //옵션 창 닫기
            Time.timeScale = 1f;
        }
    }

}
