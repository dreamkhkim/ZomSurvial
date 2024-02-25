using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        Debug.Log("���");
    }
    // Update is called once per frame
    void Update()
    {
        if(audioSource.isPlaying == false)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + "�������");
        }
    }
}
