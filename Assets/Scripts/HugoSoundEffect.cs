using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugoSoundEffect : MonoBehaviour
{

    AudioSource aud;
    [SerializeField] AudioClip spin;
    [SerializeField] AudioClip clank;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play_sound1()
    {
        Debug.Log("SoundCalled1");
        aud.PlayOneShot(spin);
    }
    public void play_sound2()
    {
        Debug.Log("SoundCalled2");
        aud.PlayOneShot(clank);
    }
}
