using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MovementInfo
{
    public float movementSpeed;
    public Vector3 lastPos;
    public Vector3 newPos;
}
