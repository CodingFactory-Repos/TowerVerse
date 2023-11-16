using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int speed;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private bool isEnnemy;

    private Animator _animator;

    private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        if (isEnnemy) _navMeshAgent.speed = speed;
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

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
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