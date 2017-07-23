using UnityEngine;
using System.Collections;

public class ObstacleDetection : MonoBehaviour
{
    public Transform wallCheck;
    public LayerMask groundLayer;
    public float wallCheckRadius;
    public bool isHittingWall;

    public Transform edgeCheck;
    bool isOnEdge;

    EnemyMove moveScript;

    void Start()
    {
        moveScript = GetComponent<EnemyMove>();
    }

    void Update()
    {
        isHittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer);
        isOnEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, groundLayer);
        TurnOnObstacleCheck(isHittingWall, isOnEdge);
    }

    void TurnOnObstacleCheck(bool hittingWall, bool onEdge)
    {
        if (hittingWall || !onEdge)
        {
            
            //moveScript.ChangeDirection();
        }
    }
}
