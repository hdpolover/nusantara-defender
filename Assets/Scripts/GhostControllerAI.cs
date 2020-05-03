using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GhostControllerAI : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private float wanderDistance = 5;

    public GhostObject ghost;

    private void Start()
    {
        if (navAgent == null)
        {
            navAgent = this.GetComponent<NavMeshAgent>();
        }
            
        if (ghost != null)
        {
            LoadGhost(ghost);
        }
         
    }

    private void LoadGhost(GhostObject _data)
    {
        //remove children objects i.e. visuals
        foreach (Transform child in this.transform)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(child.gameObject);
            }
            else
            {
                Destroy(child.gameObject);
            }    
        }

        //load current enemy visuals
        GameObject ghostModel = Instantiate(_data.model);
        ghostModel.transform.SetParent(this.transform);
        ghostModel.transform.localPosition = new Vector3(0f, 1f, 0f);
        ghostModel.transform.rotation = Quaternion.identity;

        //use stats data to set up enemy
        if (navAgent == null)
        {
            navAgent = this.GetComponent<NavMeshAgent>();
        }
            
        this.navAgent.speed = _data.movementSpeed;
    }

    private void Update()
    {
        if (ghost == null)
        {
            return;
        }

        if (navAgent.remainingDistance < 1f)
        {
            GetNewDestination();
        }
            
    }

    private void GetNewDestination()
    {
        Vector3 nextDestination = this.transform.position;
        nextDestination += wanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, 3f, NavMesh.AllAreas))
        {
            navAgent.SetDestination(hit.position);
        }
            
    }

}