using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    void Update()
    {   
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(player.position.x + offset.x , currentPosition.y , currentPosition.z);
    }
}
