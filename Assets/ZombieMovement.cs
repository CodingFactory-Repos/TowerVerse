using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private Transform destination;
    
    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found" + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (destination == null) throw new System.NotImplementedException();
        var targetVector = destination.transform.position;
        _navMeshAgent.SetDestination(targetVector);
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
