using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Sound_Cadi : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnChangePos(MovementInfo info)
    {
        source.volume = info.movementSpeed * 10f;
    }

}
