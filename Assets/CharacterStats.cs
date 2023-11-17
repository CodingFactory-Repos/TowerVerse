using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterStats : MonoBehaviour
{

    [SerializeField] public float maxHealth;
     public float currentHealth;
    [SerializeField] public int speed;
    [SerializeField] public int attackDamage;
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
        if (isEnnemy) _navMeshAgent.speed = speed;
        currentHealth = maxHealth;
    }


    // Update is called once per frame
    private void Update()
    {
        // TakeDamage(attackDamage);
    }

    private void LateUpdate()
    {
        //Die();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("aie : -" +  damage);
        currentHealth -= damage;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void Die()
    {
        if (currentHealth > 0) return;
        var dead = Animator.StringToHash("Dead");
        _animator.SetBool(dead, true);
        StartCoroutine(DestroyCouroutine());
    }

    private IEnumerator DestroyCouroutine()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}