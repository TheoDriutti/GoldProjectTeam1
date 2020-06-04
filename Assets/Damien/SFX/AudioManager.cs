using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip bounce;
    public AudioClip button;
    public AudioClip loose;
    public AudioClip PickInv;
    public AudioClip PickLvl;

    private AudioSource audio;

    void Start()
    {
        audio = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void ClickButton()
    {
        audio.PlayOneShot(button);
    }

    public void Bounce()
    {
        audio.PlayOneShot(bounce);
    }

    public void Loose()
    {

        audio.PlayOneShot(loose);
    }

    public void PickItemInv()
    {
        audio.PlayOneShot(PickInv);
    }

    public void PickTheLvl()
    {
        audio.PlayOneShot(PickLvl);
    }
}
