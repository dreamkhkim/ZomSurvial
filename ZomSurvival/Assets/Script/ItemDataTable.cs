using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjs", menuName = "ScriptableOjbects/ItemDataTable")]
public class ItemDataTable : ScriptableObject
{
    //StateType stateType; // 나중에 쓰자
    public List<ScriptableObjItem> table = new List<ScriptableObjItem>();
}
