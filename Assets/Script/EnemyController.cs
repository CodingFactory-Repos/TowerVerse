using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float maxHealth = 3;
    [SerializeField] private int speed;
    [Header("Combat")]
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float attackSpeed = 3f;
    [SerializeField] private float aggroRange= 10f;

    private NavMeshAgent _navMeshAgent;
    private float health;
    public GameObject player;
    private Animator animator;
    public Health healthBar;

    public Collider _LeftHand;
    // public Collider _RightHand;
    public LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            Debug.Log(other.gameObject);
            CharacterStats player = other.gameObject.GetComponentInParent<CharacterStats>();
            player.TakeDamage(attackDamage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        healthBar = GetComponentInChildren<Health>();
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(maxHealth, health);
        animator.SetTrigger("damage");
        if(health <= 0) {
            Die();
        }
    }

    public void StartDealDamage()
    {
        Debug.Log("toto");
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamagetest();
    }

    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamagetest();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

}
