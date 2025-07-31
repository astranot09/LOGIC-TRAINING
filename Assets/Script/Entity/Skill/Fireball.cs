using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{
    public float damage = 2;
    public float speed;
    public float direction;
    public GameObject effectFireBall;

    [SerializeField] private List<GameObject> effectFireballObjPooling;
    private TrailRenderer trail;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(direction * speed, transform.position.y)  * Time.deltaTime;
        Debug.Log(rb.velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Idamageable damageable = collision.GetComponent<Idamageable>();
        IDistructable distructable = collision.GetComponent<IDistructable>();
        if (collision.CompareTag("Player")) return;

        if (collision.CompareTag("Wall"))
        {
            if (effectFireBall != null)
            {
                SpawnEffect();
            }
            gameObject.SetActive(false);
            trail.Clear();
            Debug.Log(collision.name);
        }

        if (distructable != null)
        {
                if (effectFireBall != null)
                {
                SpawnEffect();
                }
            distructable.TakeDamage();
        }
        
        if(damageable != null )
            {
                if (effectFireBall != null)
                {
                    SpawnEffect();
                }
                damageable.TakeDamage(damage);
                gameObject.SetActive(false);
                trail.Clear();
                Debug.Log(collision.name);
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
