using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class IA_Follow : MonoBehaviour
{
    public Vector3 positionToReach;

    public IA_Stats_Scriptable iaStats;
    public bool isRunning = false;
    private bool positionSet = false;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetNewPositionToReach(Vector3 newPositionToReach)
    {
        if(!agent)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        positionToReach = newPositionToReach;
        Debug.Log(agent);
        agent.SetDestination(positionToReach);
        positionSet = true;
    }

    private void Update()
    {
        if (agent)
        {
            if (iaStats)
            {
                if (positionSet)
                {
                    if(isRunning)
                    {
                        agent.speed = iaStats.runningSpeed;
                    }
                    else
                    {
                        agent.speed = iaStats.walingSpeed;
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
}
