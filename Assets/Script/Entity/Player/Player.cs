using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity, Idamagetable
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
        healthbar.fillAmount = health/maxHealth;
    }

}
