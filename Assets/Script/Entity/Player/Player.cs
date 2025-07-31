using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity, Idamageable
{
    [Header("Stats")]
    public float maxHealth;

    [Header("References")]
    public Image healthbar;
    public float health { get; set; }
    
    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        if(health/maxHealth == 1)
        {
            healthbar.gameObject.SetActive(false);
        }
        else
        {
            healthbar.gameObject.SetActive(true);
        }
            healthbar.fillAmount = health / maxHealth;
    }

}
