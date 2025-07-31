using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : Enemy
{
    public List<State> states;
    public List<Condition> conditions;

    void Update()
    {
        for(int i=0; i<conditions.Count; i++)
        {
            if (conditions[i].CheckCondition())
            {
                states[i].enabled = true;
            }
            else
            {
                states[i].enabled = false;
            }
        }
    }













}
