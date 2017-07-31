using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour {

    private Rigidbody2D rb2D;
    private Seeker seeker;
    private EnemyMoveFollow enemyMove;

    public Transform target;

    [SerializeField]
    private float updateRate = 2;

    public Path path;

    [HideInInspector]
    public bool pathHasEnded = false;

    public float nextWaypointDistance = 3;

    private int currentWaypoint;

    public float speed;
    public ForceMode2D forceMode;

    float nextWayPointX;

    [SerializeField]
    bool canFly;


    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        enemyMove = GetComponent<EnemyMoveFollow>();

        if (target == null)
        {
            Debug.LogError("Target is missing");
            return;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(UpdatePath());
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Target is missing");
            return;
        }
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathHasEnded)
            {
                return;
            }
            Debug.Log("Path has ended");
            pathHasEnded = true;
            return;
        }
        pathHasEnded = false;
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        //Add checking direction here
        //check transform.position.x and nextWayPoint.pos.x and base on that make the enemy face right or left 

        nextWayPointX = path.vectorPath[currentWaypoint].x;

        if (canFly)
        {
            enemyMove.Move(dir.x, dir.y);
            enemyMove.CheckDirection(target.transform.position.x);
        }
        if (!canFly)
        {
            enemyMove.Move(dir.x);
            enemyMove.CheckDirection(target.transform.position.x);
        }
       
        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
        //Vector2 nextWaypoint = path.vectorPath[currentWaypoint].normalized;
        //if (nextWaypoint.x > transform.position.x)
        //{
        //    enemyMove.isMovingRight = true;
        //}
        //else if (nextWaypoint.x < transform.position.x)
        //{
        //    enemyMove.isMovingRight = false;
        //}
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            Debug.LogError("Target is missing");
            yield return false;
        }
        Debug.Log("Coroutin executed");
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete (Path p)
    {
        Debug.Log("Path was calculated: " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
	
	
	
}
