using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRadius : Condition
{
        public float minRadiusTrigger;
        public float maxRadiusTrigger;
        private Transform player;

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        public override bool CheckCondition()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < maxRadiusTrigger && distanceToPlayer >= minRadiusTrigger)
                {
                    return true;
                }
                return false;
        }
    
}
