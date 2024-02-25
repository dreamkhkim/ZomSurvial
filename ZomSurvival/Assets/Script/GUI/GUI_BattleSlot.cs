using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUI_BattleSlot : MonoBehaviour
{
    public ScriptableObjItem data;
    public TextMeshProUGUI nameLabel;
    public Image img;
    public TextMeshProUGUI skillLabel;

    // Start is called before the first frame update
    void OnEnable()
    {
        this.GetComponent<Weapon>().Init(data);
        nameLabel.text = data.Item.name;
        img.sprite = data.Item.img;
        skillLabel.text = data.Item.skillName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
