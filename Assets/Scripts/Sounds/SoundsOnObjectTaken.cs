using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundsOnObjectTaken : MonoBehaviour
{
    public AudioClip pq;
    public AudioClip water;
    public AudioClip chips;
    public AudioClip pasta;
    public AudioClip beer;
    public AudioClip softBread;
    public AudioClip croquettes;
    public AudioClip switchConsole;

    private AudioSource source;

    private float not100timesPLS = 0;

    private void Update()
    {
        if(not100timesPLS >= 0)
        {
            not100timesPLS -= Time.deltaTime;
        }
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void OnTakeItem(string tag)
    {
        if (not100timesPLS <= 0)
        {
            not100timesPLS = 0.2f;
            switch (tag)
            {
                case "beer":
                    source.PlayOneShot(beer, Random.Range(0.5f, 0.8f));
                    break;
                case "chips":
                    source.PlayOneShot(chips, Random.Range(0.5f, 0.8f));
                    break;
                case "toiletpaper":
                    source.PlayOneShot(pq, Random.Range(0.5f, 0.8f));
                    break;
                case "pasta":
                    source.PlayOneShot(pasta, Random.Range(0.5f, 0.8f));
                    break;
                case "water":
                    source.PlayOneShot(water, Random.Range(0.5f, 0.8f));
                    break;
                case "switch":
                    source.PlayOneShot(switchConsole, Random.Range(0.5f, 0.8f));
                    break;
                case "softbread":
                    source.PlayOneShot(softBread, Random.Range(0.5f, 0.8f));
                    break;
                case "croquete":
                    source.PlayOneShot(croquettes, Random.Range(0.5f, 0.8f));
                    break;
            }
        }
    }
}
