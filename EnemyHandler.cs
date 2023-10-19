using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHandler : MonoBehaviour
{
    public NavMeshAgent[] agent;
    public GameObject objective;

    // Start is called before the first frame update
    void Start()
    {
        foreach (NavMeshAgent agent in agent)
            agent.SetDestination(objective.transform.position);
    }
}
