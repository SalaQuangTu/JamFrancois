using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public struct CollisionInfos
{
    public GameObject objectCollided;
    public LayerMask maskOfObjectCollided;
}
