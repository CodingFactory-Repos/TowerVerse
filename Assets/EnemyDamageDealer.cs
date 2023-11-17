using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{

    public bool canDealDamage;
    public bool hasDealtDamage;

    public float weaponLenght;
    public float weaponDamage;

    public LayerMask layerMask;


    // Start is called before the first frame update
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            RaycastHit hit;

           // int layerMask = 1 << 7;

    
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLenght, layerMask))
            {
                Debug.LogWarning(hit.transform.gameObject);
                if (hit.transform.TryGetComponent(out CharacterStats playerState) )
                {
                    Debug.LogWarning(weaponDamage);
                    playerState.TakeDamage(weaponDamage);
                    Debug.LogWarning("enemy has dealt damage");
                    hasDealtDamage = true;
                }
            }
        }
    }

    public void StartDealDamagetest()
    {
        Debug.Log("toto");
        canDealDamage = true;
        hasDealtDamage = false;
    }

    public void EndDealDamagetest()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLenght);
    }
}
