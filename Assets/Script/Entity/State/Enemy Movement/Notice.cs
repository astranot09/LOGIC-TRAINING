using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : State
{
    private Transform Transform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1f, 5f, 1f);
    }
}
