
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GUI_PopupBattleSelectWeapon : Popup
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    Button cSlotButton1;
    Button cSlotButton2;
    Button cSlotButton3;
    void Start()
    {
        cSlotButton1 = slot1.GetComponent<Button>();

        cSlotButton2 = slot2.GetComponent<Button>();

        cSlotButton3 = slot3.GetComponent<Button>();

        cSlotButton1.onClick.AddListener(()=> OnClick(cSlotButton1));
        cSlotButton2.onClick.AddListener(() => OnClick(cSlotButton2));
        cSlotButton3.onClick.AddListener(() => OnClick(cSlotButton3));
    }

    void OnClick(Button button)
    {
        ItemMgr.Instance().PickItem = button.GetComponent<Weapon>();
        Debug.Log(ItemMgr.Instance().PickItem.index);
        PopupMgr.Instance().DisablePopup(this.gameObject);
        Time.timeScale = 1f;
    }
}
