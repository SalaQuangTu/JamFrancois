using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShelves : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> shelvesType = new List<GameObject>();
    [HideInInspector] public List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField]
    private List<GameObject> spawnedShelves = new List<GameObject>();
    [SerializeField]
    private List<string> spawnedType = new List<string>();

    public List<string> GetGroceryType
    {
        get { return spawnedType; }
    }

    public int numberOfShelves;
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
        if(numberOfShelves < spawnPoints.Count)
        {
            foreach (GameObject sp in spawnPoints)
            {
                int i = (int)Mathf.Round(Random.Range(0, shelvesType.Count));
                GameObject shelve = Instantiate(shelvesType[i], sp.transform.position, Quaternion.identity);
                shelve.transform.parent = sp.transform;
                spawnedShelves.Add(shelve);
                if (!spawnedType.Contains(shelve.tag) && shelve.tag != "Untagged" && shelve.tag != "Default") spawnedType.Add(shelve.tag);
                numberOfShelves++;
            }
        }
    }
}
