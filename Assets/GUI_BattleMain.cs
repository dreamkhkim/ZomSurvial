using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GUI_BattleMain : MonoBehaviour
{
    float sec=0f;
    int min=0;

    [SerializeField]
    TextMeshProUGUI timeTex;
    [SerializeField]
    Image hpBar;
    [SerializeField]
    Image expBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        hpBar.fillAmount = Mathf.Lerp(0, 1, BattleMgr.battleMgr.makeComplitePlayer.hp / (float)BattleMgr.cashPlayerHp);

        if (BattleMgr.player.GetComponent<Player>().exp > 0)
        {
            expBar.fillAmount = Mathf.Lerp(0, 1, (BattleMgr.battleMgr.makeComplitePlayer.exp / BattleMgr.battleMgr.maxExpOfPlayer));
        }
        else
        {
            expBar.fillAmount = 0;
        }


    }

    void Timer()
    {
        sec += Time.deltaTime;
        
        timeTex.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);

        if (sec >= 59)
        {
            sec = 0;
            min++;
        }
    }
}
