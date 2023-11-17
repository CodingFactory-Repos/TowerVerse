using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    public bool canDealDamage;
    public List<GameObject> hasDealtDamage;
    public float weaponLenght;
    public float weaponDamage;

    // Start is called before the first frame update
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 9;
         //   Debug.Log("Start can deal damage ");
            if (Physics.Raycast(transform.position,-transform.up, out hit, weaponLenght, layerMask)) {
                Debug.Log(hit.ToString());
                if(hit.transform.TryGetComponent(out EnemyController enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    enemy.TakeDamage(weaponDamage);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position-transform.up*weaponLenght);
    }
}
