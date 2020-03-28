using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(IA_ShoppingList), typeof(IA_Follow))]
public class IA_Controller : MonoBehaviour
{
    Animator iaStates;
    IA_ShoppingList shoppingList;
    IA_Follow iaAgent;

    public UnityEvent grabItem;
    public UnityEvent startRun;
    public UnityEvent StopRun;
    private void Awake()
    {
        iaStates = GetComponent<Animator>();
        iaAgent = GetComponent<IA_Follow>();
        shoppingList = GetComponent<IA_ShoppingList>();
        startRun.Invoke();
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

        if (tag == "Player")
        {
            Debug.Log("Player Touched");
            StopRun.Invoke();
            iaAgent.crashedOnPlayer = true;
            StartCoroutine(StopForXSeconds(1));
        }
    }

    public void TakeObject()
    {
        grabItem.Invoke();
        StopRun.Invoke();
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
        startRun.Invoke();
        iaStates.SetTrigger("NextState");
        yield return null;
    }

    public IEnumerator StopForXSeconds(float timeToReach)
    {
        float timer = 0;
        while (timer < timeToReach)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        //shoppingList.SelectNextArticle();
        startRun.Invoke();
        iaAgent.crashedOnPlayer = false;
        //iaStates.SetTrigger("NextState");
        yield return null;
    }
}
