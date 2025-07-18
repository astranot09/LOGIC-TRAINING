using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health")]
    public float health = 1;
    public float maxHealth = 10;

    private Rigidbody2D rb;


    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        StartCoroutine(spawnCountDown(2f));
    }
    public IEnumerator spawnCountDown(float respawn)
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(respawn);
        gameObject.SetActive(true);
        health = maxHealth;
        
    }

}
