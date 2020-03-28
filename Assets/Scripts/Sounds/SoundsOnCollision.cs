using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsOnCollision : MonoBehaviour
{
    public AudioClip[] collideSounds = new AudioClip[0];
    public string tagToTest = "";
    public LayerMask maskToTest = 0;
    [Range(0,1)]
    public float volume = 1;


    private int lastOnePlayed = -1;
    

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySoundOnCollisionTagBased(CollisionInfos info)
    {
        if (source)
        {
            if (collideSounds.Length > 1)
            {
                if (info.objectCollided.CompareTag(tagToTest))
                {
                    int rand = 0;
                    int breakLoop = 0;
                    do
                    {
                        breakLoop++;
                        rand = Random.Range(0, collideSounds.Length);
                    } while (rand == lastOnePlayed && breakLoop < 10);
                    source.PlayOneShot(collideSounds[rand], volume);
                    lastOnePlayed = rand;
                }
            }
            else
            {
                source.PlayOneShot(collideSounds[0], volume);
            }
        }
        else
        {
            Debug.Log("SoundsOnCollision: AudioSource = null", gameObject);
        }
    }


    public void PlaySoundOnCollisionMaskBased(CollisionInfos info)
    {
        if (source)
        {
            if (collideSounds.Length > 1)
            {
                if (((1<<info.maskOfObjectCollided) & maskToTest)!=0)
                {
                    int rand = 0;
                    int breakLoop = 0;
                    do
                    {
                        breakLoop++;
                        rand = Random.Range(0, collideSounds.Length);
                    } while (rand == lastOnePlayed && breakLoop < 10);
                    source.PlayOneShot(collideSounds[rand], volume);
                    lastOnePlayed = rand;
                }
            }
            else
            {
                source.PlayOneShot(collideSounds[0], volume);
            }
        }
        else
        {
            Debug.Log("SoundsOnCollision: AudioSource = null", gameObject);
        }
    }

}
