using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private bool patrolWaiting;
    [SerializeField] private float totalWaitTime = 3f;
    [SerializeField] private float switchProbability = 0.2f;
    [SerializeField] private List<Waypoint> patrolPoints;
    [SerializeField] private bool isInPatrol;

    private Animator _animator;
    private int _currentPatrolIndex;

    private NavMeshAgent _navMeshAgent;
    private bool _patrolForward;
    private bool _travelling;
    private bool _waiting;

    private float _waitTimer;

    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found" + gameObject.name);
        }
        else
        {
            if (patrolPoints is { Count: >= 2 })
            {
                _currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behavior.");
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false;
            if (patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (!_waiting) return;
        _waitTimer += Time.deltaTime;
        if (!(_waitTimer >= totalWaitTime)) return;
        _waiting = false;

        ChangePatrolPoint();
        SetDestination();
    }

    private void SetDestination()
    {
        if (patrolPoints == null) return;
        var targetVector = patrolPoints[_currentPatrolIndex].transform.position;
        _navMeshAgent.SetDestination(targetVector);
        _travelling = true;
    }

    private void ChangePatrolPoint()
    {
        if (!isInPatrol)
        {
            var walking = Animator.StringToHash("Walking");
            _animator.SetBool(walking, false);
            return;
        }

        if (Random.Range(0f, 1f) <= switchProbability) _patrolForward = !_patrolForward;

        if (_patrolForward)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--_currentPatrolIndex < 0) _currentPatrolIndex = patrolPoints.Count - 1;
        }
    }
}