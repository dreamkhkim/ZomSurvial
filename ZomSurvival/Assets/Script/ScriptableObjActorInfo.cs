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
    public uint coin; // 재화
    public int level; // 레벨
    public float exp; // 경험치
    public int hp; //  HP
    public int defense; // 방어력
    public int attack; // 공격력
    public float speed; // 스피드
    public float buffRecovery; // 버프 수치
    //---------------------------------------------------------------------------------------//

    public ActorType ActorType { get { return actorType; } } //get only
}
