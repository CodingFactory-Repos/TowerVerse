using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiPatrol : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    // Patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    // State change
    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;
    Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if(!playerInSight && !playerInAttackRange) Patrol();
        if(playerInSight && !playerInAttackRange) Chase();
        if(playerInSight && playerInAttackRange) Attack();

       
    }

    void Patrol() {
        if(!walkpointSet) SearchForDestination();
        if(walkpointSet) agent.SetDestination(destPoint);
        if(Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchForDestination() {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer)) {
            walkpointSet = true;
        }
    }

    void Chase() {
        agent.SetDestination(player.transform.position);
    }

    void Attack() {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack(1)")) {
            animator.SetTrigger("Attack");
            agent.SetDestination(transform.position);
        }
    }
}
