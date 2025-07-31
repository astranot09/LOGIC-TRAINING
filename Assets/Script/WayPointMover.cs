using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{
    public Transform wayPointParent;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    public bool loopWaypoints = true;

    private Transform[] waypoints;
    private int currentWayPointIndex;
    private bool isWaiting;

    private void Start()
    {
        waypoints = new Transform[wayPointParent.childCount];
        for (int i = 0; i < wayPointParent.childCount; i++) 
        {
            waypoints[i] = wayPointParent.GetChild(i);
        }
    }
    private void Update()
    {
        if (isWaiting) 
        {
            return;
        }
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWayPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWayPointIndex = loopWaypoints ? (currentWayPointIndex + 1) % waypoints.Length : Mathf.Min(currentWayPointIndex + 1, waypoints.Length - 1);

        isWaiting = false;
    }

}
