using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterStats : MonoBehaviour
{

    [SerializeField] public float maxHealth;
     public float currentHealth;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float runSpeed;
    [SerializeField] public float attackDamage;
    [SerializeField] public float attackRange;
    [SerializeField] public float attackSpeed;
    [SerializeField] private bool isEnnemy;

    private Animator _animator;

    private NavMeshAgent _navMeshAgent;

    public Health healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        if (isEnnemy) _navMeshAgent.speed = walkSpeed;
        currentHealth = maxHealth;
        setValue();
    }

    private void setValue()
    {
        var main = MainHolder.instance;
            maxHealth = main._maxHealth;
            attackDamage = main._damage;
            walkSpeed = main._walkSpeed;
            attackSpeed = main._attackSpeed;
            attackRange = main._attackRange;
            runSpeed = main._runSpeed;
    }


    // Update is called once per frame
    private void Update()
    {
        // TakeDamage(attackDamage);
    }

    private void LateUpdate()
    {
        Die();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("aie : -" +  damage);
        currentHealth -= damage;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void Die()
    {
        if (currentHealth > 0) return;
       // _animator.SetTrigger("Dead");
        StartCoroutine(DestroyCouroutine());
    }

    private IEnumerator DestroyCouroutine()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}