using System;
using UnityEngine;


public enum ActorType
{
    Player,
    Monster,

    End,
}

[CreateAssetMenu(fileName = "ScriptableObjs", menuName = "ScriptableOjbects/ActorInfo")]
public class ScriptableObjActorInfo : ScriptableObject
{
    public ActorType actorType;
    //Actor ---------------------------------------------------------------------------------//
    public uint coin; // ��ȭ
    public int level; // ����
    public float exp; // ����ġ
    public int hp; //  HP
    public int defense; // ����
    public int attack; // ���ݷ�
    public float speed; // ���ǵ�
    public float buffRecovery; // ���� ��ġ
    //---------------------------------------------------------------------------------------//

    public ActorType ActorType { get { return actorType; } } //get only
}
