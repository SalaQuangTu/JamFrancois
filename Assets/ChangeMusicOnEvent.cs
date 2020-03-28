using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]
public class ChangeMusicOnEvent : MonoBehaviour
{
    public float lerpingTime;
    AudioSource source = null;
    [Range(0,1)]
    public float volume;

    public UnityEvent changeToLoop;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void ChangeMusic(AudioClip clip)
    {
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }

    public void ChangeMusicLoop(AudioClip clip)
    {
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }

    public void ChangeMusicLerp(AudioClip clip)
    {
        StartCoroutine(LerpMusic(clip));
    }

    IEnumerator LerpMusic(AudioClip clip)
    {
        float lerp = 0;
        AudioSource music = new AudioSource();
        music.clip = source.clip;
        music.time = source.time;
        music.volume = 1;
        source.volume = 0;

        source.clip = clip; 
        while(lerp<lerpingTime)
        {
            lerp += Time.deltaTime;
            music.volume = 1-(lerp / lerpingTime);
            source.volume = (lerp / lerpingTime);
        }
        source.volume = 1;
        yield return null;
    }

    private void Update()
    {
        if(source.clip.length - source.time <= 0f && source.loop == false)
        {
            changeToLoop.Invoke();
            source.loop = true;
            Debug.Log("Changed music");
        }
    }

}
