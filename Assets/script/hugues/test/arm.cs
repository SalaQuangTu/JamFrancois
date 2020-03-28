using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Bones;
    //public GameObject spawn;
    public float speed;
    //[Range(1,50)]
    public int spawnNumber = 0;

    public Transform wantedPos;

    int index;
    public enum type
    {
        snake,
        pile,
    }

    public type followType;
    //public enum 

    // Start is called before the first frame update

    void Start()
    {
        //Bones = new List<GameObject>();
        //var cc =  transform.childCount;
        //Bones[0] = transform.GetChild(0).gameObject;
        //Bones[cc] = transform.GetChild(cc).gameObject;

        foreach (Transform child in transform)
        {
            Bones.Add(child.gameObject);
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        Bones[0].transform.position = wantedPos.position;
 
        spawnNumber = Mathf.RoundToInt(Mathf.Clamp(spawnNumber, 0, transform.childCount));

            for (int i = 1; i < spawnNumber; i++)
            {
                if (Bones[i] != null)
                {
                    Bones[i].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    if (followType == type.pile)
                    {
                        Bones[i].transform.position = Vector3.Lerp(Bones[i].transform.position, new Vector3(Bones[i - 1].transform.position.x, Bones[i].transform.position.y, Bones[i - 1].transform.position.z), speed * Time.deltaTime);
                        Bones[i].transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
                    }
                    else if (followType == type.snake) if (Vector3.Distance(Bones[i].transform.position, Bones[i - 1].transform.position) > 1f) Bones[i].transform.position = Vector3.Lerp(Bones[i].transform.position, Bones[i - 1].transform.position, speed * Time.deltaTime);

                }

            }

            for (int i = spawnNumber; i < transform.childCount; i++)
            {
                Bones[i].gameObject.GetComponent<MeshRenderer>().enabled = false;
                Bones[i].transform.position = Vector3.Lerp(Bones[i].transform.position, new Vector3(Bones[i - 1].transform.position.x, Bones[i].transform.position.y, Bones[i - 1].transform.position.z), speed * Time.deltaTime);
            }
       

        //start.transform.position = Vector3.Lerp(start.transform.parent.position,transform.parent.position, speed * Time.deltaTime);
        //joint1.transform.position = Vector3.Lerp(joint1.transform.position, new Vector3(start.transform.position.x, joint1.transform.position.y, start.transform.position.z), speed * Time.deltaTime);
        //joint2.transform.position = Vector3.Lerp(joint2.transform.position, new Vector3(joint1.transform.position.x, joint2.transform.position.y, joint1.transform.position.z), speed * Time.deltaTime);
        //end.transform.position = Vector3.Lerp(end.transform.position, new Vector3(joint2.transform.position.x, end.transform.position.y, joint2.transform.position.z), speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        
        for (int i = 0; i < Bones.Count; i++)
        {
            if (Bones[i].gameObject != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(Bones[i].transform.position, 0.2f);
                Gizmos.color = Color.yellow;
                if (i <= Bones.Count - 2) Gizmos.DrawLine(Bones[i].transform.position, Bones[i + 1].transform.position);
            }
        }

        //Gizmos.DrawWireSphere(joint2.transform.position, 0.2f);
        //Gizmos.DrawWireSphere(end.transform.position, 0.4f);

        //Gizmos.DrawLine(start.transform.position, joint1.transform.position);
        //Gizmos.DrawLine(joint1.transform.position, joint2.transform.position);
        //Gizmos.DrawLine(joint2.transform.position, end.transform.position);
    }

    public void IncreaseSpawnNumber()
    {
        spawnNumber++;
    }

}
