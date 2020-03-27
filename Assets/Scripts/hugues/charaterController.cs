using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    public float rotationSpeed;
    public float moveAcceleration;
    public float moveDecceleration;
    public float turnAcceleration;
    public float reactivity;
    //public float turnDecceleration;
    float turnTime;
    float moveTime;
    float x, y;
    Camera cam;

    Vector3 wantedDir;
    Vector3 finalDir;
    Quaternion wantedRot;
    GameObject grab;
    GameObject shelve;

    bool grabItem;
    void Start()
    {
        cam = Camera.main;
       // grab = GameObject.FindGameObjectWithTag("grab");

    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        var forward = Vector3.Cross(cam.transform.right, Vector3.up);
        var right = Vector3.Cross(cam.transform.forward, Vector3.up);
        if(x != 0 || y != 0)
        {

            var rateMov = 1.0f / moveAcceleration;
            if (moveTime < 1.0f)
            {
                moveTime += Time.fixedDeltaTime * rateMov;
            }

            var rateRot = 1.0f / turnAcceleration;
            if(turnTime < 1.0f)
            {
                turnTime += Time.fixedDeltaTime * rateRot;
            }

            wantedDir = right * -x + forward * y;
            finalDir = Vector3.Lerp(finalDir, wantedDir, reactivity * Time.fixedDeltaTime);
        }
        else
        {
            turnTime = 0;
            var rateMov = 1.0f / moveDecceleration;
            if (moveTime > 0.0f)
            {
                moveTime -= Time.fixedDeltaTime * rateMov;
            }
        }

        wantedRot = Quaternion.LookRotation(wantedDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRot, (rotationSpeed * turnTime) * Time.fixedDeltaTime);
        transform.position = Vector3.Lerp(transform.position, transform.position + finalDir, (movementSpeed * moveTime) * Time.fixedDeltaTime);
        if(grabItem)
        {
            Debug.Log("Entered trigger");
            Vector3 shelvePos = new Vector3(shelve.transform.position.x, transform.position.y, shelve.transform.position.z);
            var dir = shelvePos - transform.position;
            Debug.DrawLine(transform.position, transform.position + dir * 2f, Color.blue);
            //float dot = Vector3.Dot(Vector3.right, dir);
            //Debug.Log(dot);
            //grab.transform.position = transform.position + transform.right.normalized;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    grabItem = true;
    //    shelve = other.gameObject;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    grabItem = false;
    //}
}
