using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShelves : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> shelvesType = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField]
    private List<GameObject> spawnedShelves = new List<GameObject>();
    [SerializeField]
    private List<string> spawnedType = new List<string>();
    [HideInInspector]
    public int numberOfShelves;
    int index;
    int randomize;
    List<int> randomizedList = new List<int>();
    int nbType;
    void Start()
    {
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfShelves < spawnPoints.Count)
        {
            //foreach (GameObject sp in spawnPoints)
            //{
            //    if (index < shelvesType.Count)
            //    {
            //        randomize = Mathf.RoundToInt(Random.Range(0, numberOfShelves));

            //        if (!randomizedList.Contains(randomize))
            //        {
            //            GameObject shelve = Instantiate(shelvesType[index], sp.transform.position, shelvesType[index].transform.rotation);

            //            randomizedList.Add(randomize);
            //            shelve.transform.parent = sp.transform;
            //            spawnedShelves.Add(shelve);
            //            numberOfShelves++;
            //            index++;
            //        }
            //        else randomize = Mathf.RoundToInt(Random.Range(0, numberOfShelves));

            //    }
            //var random = Random.Range(0, numberOfShelves);
            //Debug.Log(random);
            //}
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                //var random = Random.Range(0, spawnPoints.Count);
                //var random1 = Random.Range(0, spawnPoints.Count);

                randomize = Random.Range(0, shelvesType.Count);
                //Debug.Log(randomize);

                if (randomizedList.Count < shelvesType.Count)
                {
                    while (randomizedList.Contains(randomize))
                    {
                        //Debug.Log("already : " + randomize);
                        randomize = Random.Range(0, shelvesType.Count);
                    }

                        GameObject shelve = Instantiate(shelvesType[randomize], spawnPoints[i].transform.position, shelvesType[randomize].transform.rotation);

                        shelve.transform.parent = spawnPoints[i].transform;
                        spawnedShelves.Add(shelve);
                        randomizedList.Add(randomize);

                    
                }
                else
                {
                    GameObject shelve = Instantiate(shelvesType[randomize], spawnPoints[i].transform.position, shelvesType[randomize].transform.rotation);

                    shelve.transform.parent = spawnPoints[i].transform;
                    spawnedShelves.Add(shelve);
                    randomizedList.Add(randomize);
                }

                numberOfShelves++;
            }
        }
        if (nbType < spawnedShelves.Count)
        {
            foreach (var type in spawnedShelves)
            {
                nbType++;
                if (!spawnedType.Contains(type.tag) && type.tag != "Untagged") spawnedType.Add(type.tag); ;
            }
        }

    }

    public List<string> GetGroceryType
    {
        get { return spawnedType; }
    }
}
