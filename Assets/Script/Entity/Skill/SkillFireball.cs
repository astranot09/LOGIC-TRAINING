using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFireball : MonoBehaviour
{
    public GameObject fireballObj;
    public KeyCode keyBind;
    public float cooldown;

    [SerializeField] private List<GameObject> fireballObjPooling;
    private float currentCooldown;
    private float lastDirection = 1;
    private void Start()
    {
        currentCooldown = cooldown;
    }

    public void Update()
    {

        float input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            lastDirection = input;
        }

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(keyBind))
        {
            if(currentCooldown > 0)
            {
                Debug.Log("CD");
            }
            else if (currentCooldown <= 0)
            {
                SpawnFireball();
                currentCooldown = cooldown;
            }

        }

    }
    public void SpawnFireball()
    {
        for(int i = 0; i < fireballObjPooling.Count; i++)
        {
            if (!fireballObjPooling[i].activeInHierarchy)
            {
                fireballObjPooling[i].SetActive(true);
                fireballObjPooling[i].transform.position = transform.position;
                fireballObjPooling[i].GetComponent<Fireball>().direction = lastDirection;
                return;
            }
        }
        GameObject fireBall = Instantiate(fireballObj, transform.position, Quaternion.identity);
        fireBall.GetComponent<Fireball>().direction = lastDirection;
        fireballObjPooling.Add(fireBall);
    }
}
