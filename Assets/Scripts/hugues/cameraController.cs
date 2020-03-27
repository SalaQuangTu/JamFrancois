using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform lookAt;

    private Transform camTransform;

    [Range(0, 50)]
    public float cameraSmoothness = 8;

    public float Y_Angle = -85f;

    [Range(0, 15)]
    public float distance = 15f;
    [Range(0, 15)]
    public float height = 15f;

    private void Start()
    {

        camTransform = transform;

        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {

        camTransform.LookAt(lookAt.position);

    }
    private void FixedUpdate()
    {
        Vector3 dist = new Vector3(0, height, -distance);
        var wantedPos = lookAt.position + dist;
        camTransform.position = Vector3.Lerp(transform.position, wantedPos, cameraSmoothness * Time.deltaTime);
    }

}