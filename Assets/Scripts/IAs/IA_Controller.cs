using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(IA_ShoppingList), typeof(IA_Follow))]
public class IA_Controller : MonoBehaviour
{
    Animator iaStates;
    IA_ShoppingList shoppingList;
    IA_Follow iaAgent;

    private void Awake()
    {
        iaStates = GetComponent<Animator>();
        iaAgent = GetComponent<IA_Follow>();
        shoppingList = GetComponent<IA_ShoppingList>();
    }

    private void OnEnable()
    {
        iaAgent = GetComponent<IA_Follow>();
        iaAgent.collideWithObject.AddListener(OnCollisionWithObject);    
    }

    private void OnDisable()
    {
        iaAgent = GetComponent<IA_Follow>();
        iaAgent.collideWithObject.RemoveListener(OnCollisionWithObject);

    }

    void OnCollisionWithObject(string tag)
    {
        if(tag == shoppingList.currentTagToSearch)
        {
            TakeObject();
            iaStates.SetTrigger("NextState"); //=> Get Object
        }
    }

    public void TakeObject()
    {
        StartCoroutine(WaitForXSeconds(iaAgent.iaStats.waitingTimeOnObject));//Wait x seconds before going on;
    }


    public IEnumerator WaitForXSeconds(float timeToReach)
    {
        float timer = 0;
        while(timer < timeToReach)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Yop", gameObject);
        shoppingList.SelectNextArticle();
        iaStates.SetTrigger("NextState");
        yield return null;
    }
}
