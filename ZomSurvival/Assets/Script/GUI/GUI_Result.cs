using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GUI_Result : MonoBehaviour
{
    public GameObject getCoin;
    public GameObject playTime;
    public GameObject gotoMain;

    TextMeshProUGUI cGetCoin;
    TextMeshProUGUI cPlayTime;
    Button cGoToMain;

    float sec= 0;
    int min = 0;
    void Start()
    {

    }

    private void OnEnable()
    {
        Init();
        cGoToMain.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        PopupMgr.Instance().ClosePopup(this.gameObject);
        SceneMgr.Instance().CallScene("Territory");
    }
    void Update()
    {
    }

    void Init()
    {
       


        cGetCoin = getCoin.GetComponent<TextMeshProUGUI>();
        cPlayTime = playTime.GetComponent<TextMeshProUGUI>();
        cGoToMain = gotoMain.GetComponent<Button>();

        GameObject battleObj = GameObject.FindGameObjectWithTag("BattleManager");
        GameManager.Coin += battleObj.GetComponent<BattleMgr>().getCoin;



        if (battleObj != null)
        {
            cGetCoin.text = battleObj.GetComponent<BattleMgr>().getCoin.ToString();
            sec += Time.time;
            if (sec >= 59)
            {
                sec = 0 + Time.time;

                min++;

            }



            cPlayTime.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
        }
    }
    
}
