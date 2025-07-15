using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFireBall : MonoBehaviour
{
    public float lifetime = 1f;

    private void OnEnable()
    {
        StartCoroutine(DisableAfterDelay());
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }

}
