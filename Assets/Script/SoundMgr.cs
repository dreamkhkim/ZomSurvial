using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;
    public GameObject soundPlayerPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Play(AudioClip audioClip, Transform referenceTransform)
    {
        GameObject soundPlayer = Instantiate(soundPlayerPrefab, referenceTransform);
        soundPlayer.GetComponent<SoundPlayer>().Play(audioClip);       
            
    }  

}
