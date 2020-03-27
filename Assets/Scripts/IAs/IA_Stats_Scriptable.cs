using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewIAStats", menuName = "Custom/New_IA_Stats", order =150)]
public class IA_Stats_Scriptable : ScriptableObject
{
    public float walingSpeed = 3;
    public float runningSpeed = 9;
    public float waitingTimeOnObject = 2;
}
