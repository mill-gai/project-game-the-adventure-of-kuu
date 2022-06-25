using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyDemo
{
    public Transform wayPoint1, wayPoint2;
    private Transform wayPointTarget;

    private void Awake() {
        wayPointTarget = wayPoint1; //At the beginning, bat move to the right waypoint
    }
    protected override void Move()
    {
        base.Move();

        // patrol b/w 2 points
        if(Vector2.Distance(transform.position, target.position) > distance)
        {
            // when we reached at the waypoint1, we have to move to the waypoint 2
            if(Vector2.Distance(transform.position, wayPoint1.position) < 0.01f) // almost reach the wayPoint1
            {
                //Debug.Log("Reach");
                wayPointTarget = wayPoint2;
            }
            if(Vector2.Distance(transform.position, wayPoint2.position) < 0.01f)
            {
               // Debug.Log("Reach:(");
                wayPointTarget = wayPoint1;
            }
            transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
        }
    }
}
