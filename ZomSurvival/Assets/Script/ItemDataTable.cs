using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjs", menuName = "ScriptableOjbects/ItemDataTable")]
public class ItemDataTable : ScriptableObject
{
    //StateType stateType; // ���߿� ����
    public List<ScriptableObjItem> table = new List<ScriptableObjItem>();
}
