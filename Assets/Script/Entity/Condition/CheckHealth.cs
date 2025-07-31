using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHealth : Condition
{
    public float healthTrigger;
    private Enemy enemyScript;

    public void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }
    public override bool CheckCondition()
    {
       if(enemyScript.health <= healthTrigger)
        {
            return true;
        }
       return false;
    }
}
