using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : State
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.color = Color.red;
    }
}
