using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attack_point;
    public float attack_radius = 1f;
    public LayerMask enemyMask;
    public LayerMask DistructableMask;
    public float damage = 1;


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attack_point.position, attack_radius);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            melleAttack();
        }
    }

    public void melleAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack_point.position, attack_radius, enemyMask | DistructableMask);

        foreach (Collider2D target in hitEnemies)
        {
            Idamageable damageable = target.GetComponent<Idamageable>();
            IDistructable distructable = target.GetComponent<IDistructable>();

            if (distructable != null)
            {
                distructable.TakeDamage();
            }

            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }

}
