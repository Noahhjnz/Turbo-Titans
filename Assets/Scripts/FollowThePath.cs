using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float movespeed = 1f;
    //holds number of waypoints - defult to 0
    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false; 

    //places player at first waypoint
    private void Start() { 
    
        transform.position = waypoints[waypointIndex].transform.position;
    }
    
    private void Update ()
    {
        if (moveAllowed)
            Move();
  
    }
    //allows player to move from one waypoint to another
    private void Move()
    {
        if (waypointIndex <= waypoints.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                movespeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
    
}
