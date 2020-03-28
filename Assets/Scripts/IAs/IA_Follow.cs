using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


[RequireComponent(typeof(NavMeshAgent))]
public class IA_Follow : MonoBehaviour
{
    public Vector3 positionToReach;

    public IA_Stats_Scriptable iaStats;
    public bool isRunning = false;

    public bool crashedOnPlayer = false;
    private bool positionSet = false;

    private NavMeshAgent agent;

    //public UnityEvent positionReached;
    public UnityEvent isGoingFowardUpdate;
    public MyStringEvent collideWithObject = new MyStringEvent();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 10;
    }

    public void SetNewPositionToReach(Vector3 newPositionToReach)
    {
        if(!agent)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        positionToReach = newPositionToReach;
        agent.SetDestination(positionToReach);
        positionSet = true;
    }

    private void Update()
    {
        if (agent)
        {
            if (iaStats)
            {
                if (!crashedOnPlayer)
                {
                    if (positionSet) // Going on
                    {
                        if (isRunning)
                        {
                            agent.speed = iaStats.runningSpeed;

                        }
                        else
                        {
                            agent.speed = iaStats.walingSpeed;
                        }

                        isGoingFowardUpdate.Invoke();
                    }
                    else
                    {
                        agent.speed = 0;
                    }
                }
                else
                {
                    agent.speed = 0;
                }
            }
            else
            {
                Debug.Log("IA_FOLLOW: MISSING iaStats", gameObject);
            }
        }
        else
        {
            Debug.Log("IA_FOLLOW: MISSING AGENT", gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IA_PositionToReachCol>() != null)
        {
            collideWithObject.Invoke(other.tag);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collideWithObject.Invoke(collision.gameObject.tag);
    }
}
