using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Idamageable
{
    float health {get; set;}
    public void TakeDamage(float damage);
}
