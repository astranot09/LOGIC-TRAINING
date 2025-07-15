using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{
    public float damage;
    public float speed;
    public float direction;
    public GameObject effectFireBall;

    [SerializeField] private List<GameObject> effectFireballObjPooling;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(direction * speed, transform.position.y)  * Time.deltaTime;
        Debug.Log(rb.velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if(effectFireBall != null)
            {
                SpawnEffect();
            }
            gameObject.SetActive(false);
        }
    }

    public void SpawnEffect()
    {
        for (int i = 0; i < effectFireballObjPooling.Count; i++)
        {
            if (!effectFireballObjPooling[i].activeInHierarchy)
            {
                effectFireballObjPooling[i].SetActive(true);
                effectFireballObjPooling[i].transform.position = transform.position;
                return;
            }
        }
        GameObject fireBall = Instantiate(effectFireBall, transform.position, Quaternion.identity);
        effectFireballObjPooling.Add(fireBall);
    }
}
