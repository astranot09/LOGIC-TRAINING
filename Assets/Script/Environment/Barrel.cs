using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour , IDistructable
{
    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }
}
