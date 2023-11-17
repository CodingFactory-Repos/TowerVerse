using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float health = 3;
    public GameObject player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        if(health <= 0) {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

}
