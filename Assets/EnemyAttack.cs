using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 1f;
    public bool canDamage = true;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Idamageable damageable = collision.GetComponent<Idamageable>();
        if (collision.CompareTag("Player") && damageable != null)
        {
            StartCoroutine(giveDamage(damageable));
        }
    }

    IEnumerator giveDamage(Idamageable damageable)
    {
        damageable.TakeDamage(damage);
        Debug.Log(damage);
        yield return new WaitForSeconds(1f);
    }
}
