using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Grabber2 : MonoBehaviour
{
    public Text score;
    public int pointPerItem;
    int totalPoint;
    public List<GameObject> objectInRange = new List<GameObject>();
    public LayerMask Items;
    public Collider[] hitColliders;

    public List<arm> arms = new List<arm>();

    public MyStringEvent onObjectTaken;
    int nbArms;
   // public arm arm;


    // Update is called once per frame
    void Update()
    {
    //    if (nbArms < arms.Count)
    //    {
    //        foreach (var item in arms)
    //        {
    //            totalPoint += item.GetNumber;

            //            nbArms++;
            //        }
            //    }

            score.text = "Score : " + totalPoint * pointPerItem;
        
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, Items);
        
        foreach (var item in hitColliders)
        {
            
            var rand = Random.Range(0f, 1f);
            objectInRange.Add(item.gameObject);
            //if (rand < 0.33f)
            //{
            
                //arm.IncreaseSpawnNumber();
            
            
                //for (int i = 0; i < arms.Count; i++)
                //{
                //    var z = item.tag;
                //    if (arms[i].gameObject.tag == z)
                //    {
                //        arms[i].IncreaseSpawnNumber();
                //    }
                //}
                //if (arm != null) arm.IncreaseSpawnNumber();
            //}
            item.GetComponent<Collider>().enabled = false;


            //}
            //else
            //{
            //    Rigidbody rb = item.transform.gameObject.AddComponent<Rigidbody>();
            //    var dir = transform.parent.position - item.transform.position;
            //    rb.AddForce(dir, ForceMode.Impulse);
            //}

        }

        for (int i = 0; i < objectInRange.Count; i++)
        {
            objectInRange[i].transform.position = Vector3.Lerp(objectInRange[i].transform.position, transform.parent.position, 5f * Time.deltaTime);
            for (int y = 0; y < arms.Count; y++)
            {
                if(objectInRange[i].tag == arms[y].tag)
                {
                    Debug.Log("Add 1  to : " + arms[y].tag);
                    onObjectTaken.Invoke(objectInRange[i].tag);
                    arms[y].IncreaseSpawnNumber();
                    totalPoint++;
                    nbArms = 0;
                }
                
                foreach(Text s in ListeDeCourse.Instance.ldc)
                {
                    if(s.text == objectInRange[i].tag)
                    {
                        ListeDeCourse.Instance.MajDeLaListe(objectInRange[i].tag);
                        break;
                    }
                }
            }
            Destroy(objectInRange[i], 0.2f);
            objectInRange.Remove(objectInRange[i]);
            
        }
            //    var dist = Vector3.Distance(transform.parent.position, item.transform.position);

            //    var rand = Random.Range(0f, 1f);
            //    //if (rand < 0.5f)
            //    //{
            //    if (dist < 0.1f)
            //    {


            //        objectInRange.Remove(item);
            //    }
            //    //}
            //    //else
            //    //{
            //    //    objectInRange.Remove(item);

            //    //}
            //}
            //foreach(var item in collected)
            //{

            //}

            //foreach (var item in objectInRange)
            //{
            //    item.GetComponent<Rigidbody>().AddForce(item.transform.right, ForceMode.Impulse);
            //}
        }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Item")
    //    {
    //        Debug.Log("sisi : " + other.name);
    //        /*bjectInRange.Add(other);*/
    //    }
    //}
}
