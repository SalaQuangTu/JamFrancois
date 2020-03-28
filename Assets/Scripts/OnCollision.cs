using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public CollisionEvents collision;

    private void OnCollisionEnter(Collision col)
    {
        CollisionInfos info = new CollisionInfos
        {
            objectCollided = col.gameObject,
            maskOfObjectCollided = col.gameObject.layer       
        };

        collision.Invoke(info);
    }
}
