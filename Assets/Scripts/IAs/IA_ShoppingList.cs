using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IA_Follow), typeof(Animator))]
public class IA_ShoppingList : MonoBehaviour
{
    [Header("Liste d'items a définirs")]
    public List<string> tagListOfAvailableItems;
    public int minNumberToTake = 1;
    public int maxNumberToTake = 3;

    [Header("Point de sortie du magasin")]
    public GameObject exitGameObject;

    [Header("Objet que l'ia recherche actuellement")]
    public string currentTagToSearch;

    [Header("Liste séléctionnée par l'IA")]
    public List<string> shoppingList;     


    private Animator iaStates;
    private IA_Follow followingScript;
    private List<Vector3> shoppingPoints;

    private int listChecker = -1;

    private void Awake()
    {
        followingScript = GetComponent<IA_Follow>();
        iaStates = GetComponent<Animator>();
        if(exitGameObject == null)
        {
            Debug.Log("IA_ShoppingList : There is no exit", gameObject);
        }
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, exitGameObject.transform.position)<0.5f)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        tagListOfAvailableItems = FindObjectOfType<SpawnShelves>().GetGroceryType;
        StartCoroutine(PopulateShoppingList());
        exitGameObject = GameObject.Find("Exit IA");
        //ShuffleList(shoppingPoints);       
    }

    private IEnumerator PopulateShoppingList()
    {
        shoppingList = new List<string>();

        int nbItemSelected = Mathf.Clamp(Random.Range(minNumberToTake, maxNumberToTake+1),0,100);
        Debug.Log("nbItems Selected" + nbItemSelected, gameObject);
        int i = 0;
        int[] alreadySelected = new int[nbItemSelected];
        for(int j = 0; j < nbItemSelected; j++)
        {
            alreadySelected[j] = -1;
            Debug.Log("Already Selected " + j + " " + alreadySelected[j]);
        }
        
        while(i < nbItemSelected)
        {
            int rand = Mathf.Clamp(Random.Range(0, maxNumberToTake), 0, 100);
            bool nope = false;
            for(int j = 0; j < shoppingList.Count; j++)
            {
                if(tagListOfAvailableItems[rand] == shoppingList[j])
                {
                    nope = true;
                }
            }
            if(!nope)
            {
                shoppingList.Add(tagListOfAvailableItems[rand]);
                Debug.Log(tagListOfAvailableItems[rand], gameObject);
                i++;
            }
        }
        SetShoppingPoints();
        yield return null;
    }
    /// <summary>
    /// Send the new position to reach to the followerScript
    /// </summary>
    public void SelectNextArticle()
    {
        if(listChecker < shoppingPoints.Count-1)
        {
            listChecker++;
            followingScript.SetNewPositionToReach(shoppingPoints[listChecker]);
            currentTagToSearch = shoppingList[listChecker];
        }
        else
        {
            followingScript.SetNewPositionToReach(exitGameObject.transform.position);
        }
    }

    /// <summary>
    /// Populate the ShoppingPoints list with position from the tag list
    /// </summary>
    public void SetShoppingPoints()
    {
        if(shoppingList.Count > 0)
        {
            shoppingPoints = new List<Vector3>();
            IA_PositionToReachCol[] toReach = GameObject.FindObjectsOfType<IA_PositionToReachCol>();

            foreach (string tag in shoppingList)
            {
                foreach (IA_PositionToReachCol pos in toReach)
                {
                    if (tag == pos.objTag)
                    {
                        Debug.Log("Item Chosed", pos.gameObject);
                        shoppingPoints.Add(pos.gameObject.transform.position);
                        break;
                    }
                }
            }
            StartCoroutine(ShuffleList(shoppingPoints, shoppingList));
        }
    }

    /// <summary>
    /// Aucune idée de si ça fonctionne xD
    /// </summary>
    /// <param name="list"></param>
    public IEnumerator ShuffleList(List<Vector3> list, List<string> tagList)
    {
        int[] randNumbers = new int[list.Count];
        List<Vector3> savedList;
        List<string> savedTagList;
        savedTagList = new List<string>();
        savedList = new List<Vector3>();

        for(int i = 0; i < list.Count; i++)
        {
            randNumbers[i] = -1;
            savedList.Add(list[i]);
            savedTagList.Add(tagList[i]);
        }

        int added = 0;
        while(randNumbers[list.Count-1] == -1)
        {
            int number = Random.Range(0, list.Count);
            bool notInThere = true;
            for(int i = 0; i < list.Count; i++)
            {
                if(randNumbers[i] == number)
                {
                    notInThere = false;
                }
            }

            if(notInThere)
            {
                randNumbers[added] = number;
                added++;
            }
        }

        for(int i = 0; i < list.Count; i++)
        {
            list[i] = savedList[randNumbers[i]];
            tagList[i] = savedTagList[randNumbers[i]];
        }

        SelectNextArticle();
        yield return null;
    }
}
