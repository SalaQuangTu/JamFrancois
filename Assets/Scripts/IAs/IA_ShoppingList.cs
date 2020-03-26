using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IA_Follow))]
public class IA_ShoppingList : MonoBehaviour
{
    public List<string> shoppingList;
    public GameObject exitGameObject;

    private IA_Follow followingScript;

    private List<Vector3> shoppingPoints;

    private int listChecker = -1;

    private void Awake()
    {
        followingScript = GetComponent<IA_Follow>();
        if(exitGameObject == null)
        {
            Debug.Log("IA_ShoppingList : There is no exit", gameObject);
        }
    }

    private void Start()
    {
        SetShoppingPoints();
        SelectNextArticle();
    }
    /// <summary>
    /// Send the new position to reach to the followerScript
    /// </summary>
    public void SelectNextArticle()
    {
        if(listChecker < shoppingList.Count)
        {
            listChecker++;
            followingScript.SetNewPositionToReach(shoppingPoints[listChecker]);
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
            foreach(string tag in shoppingList)
            {
                GameObject newPlace = GameObject.FindGameObjectWithTag(tag);
                if(newPlace != null)
                {
                    shoppingPoints.Add(newPlace.transform.position);
                }
            }
        }
    }

    /// <summary>
    /// Aucune idée de si ça fonctionne xD
    /// </summary>
    /// <param name="list"></param>
    public void ShuffleList(List<Vector3> list)
    {
        int[] randNumbers = new int[list.Count];
        List<Vector3> savedList;
        savedList = new List<Vector3>();
        for(int i = 0; i < list.Count; i++)
        {
            randNumbers[i] = -1;
            savedList.Add(list[i]);
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
            }
        }

        for(int i = 0; i < list.Count; i++)
        {
            list[i] = savedList[randNumbers[i]];
        }
    }
}
