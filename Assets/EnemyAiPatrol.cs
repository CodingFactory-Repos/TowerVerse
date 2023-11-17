using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiPatrol : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer, playerLayer;
    [SerializeField] private float range;

    // State change
    [SerializeField] private float sightRange, attackRange;

    //waypoint patrol
    [SerializeField] private bool patrolWaiting;
    [SerializeField] private float totalWaitTime = 3f;
    [SerializeField] private float switchProbability = 0.2f;
    [SerializeField] private List<Waypoint> patrolPoints;
    [SerializeField] private bool isInPatrol;
    private int _currentPatrolIndex;


    private bool _leftPatrolWaypoint;

    private bool _patrolForward;
    private bool _travelling;
    private bool _waiting;

    private float _waitTimer;


    private NavMeshAgent agent;
    private Animator animator;

    // Patrol
    private Vector3 destPoint;
    private GameObject player;
    private bool playerInSight, playerInAttackRange;

    private bool walkpointSet;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player") ?? GameObject.Find("Player Variant") ?? GameObject.Find("PlayerArmature");

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
        if (agent == null)
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
                _leftPatrolWaypoint = true;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);


        if (!playerInSight && !playerInAttackRange && !_leftPatrolWaypoint)
        {
            if (_travelling && agent.remainingDistance <= 1.0f)
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

        Debug.Log(playerInAttackRange + " " + playerInSight + " " + _leftPatrolWaypoint);

        if (!playerInSight && !playerInAttackRange && _leftPatrolWaypoint) Patrol();
        if (playerInSight && !playerInAttackRange) Chase();
        if (playerInSight && playerInAttackRange) Attack();
    }

    private void Patrol()
    {
        if (!walkpointSet) SearchForDestination();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    private void SearchForDestination()
    {
        var z = Random.Range(-range, range);
        var x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer)) walkpointSet = true;
    }

    private void SetDestination()
    {
        if (patrolPoints == null) return;
        var targetVector = patrolPoints[_currentPatrolIndex].transform.position;
        agent.SetDestination(targetVector);
        _travelling = true;
    }

    private void ChangePatrolPoint()
    {
        if (!isInPatrol)
        {
            var walking = Animator.StringToHash("Walking");
            animator.SetBool(walking, false);
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

    private void Chase()
    {
        agent.SetDestination(player.transform.position);
        _leftPatrolWaypoint = true;
    }

    private void Attack()
    {
        _leftPatrolWaypoint = true;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack(1)")) return;
        animator.SetTrigger("Attack");
        agent.SetDestination(transform.position);
    }
}