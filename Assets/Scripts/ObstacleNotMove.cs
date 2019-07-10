using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleNot
{
    public static float ObstacleRadius = 0.5f;
}

public class ObstacleNotMove : MonoBehaviour
{

    GameObject player;

    Vector2 playerPosition;

    Vector2 ObstacleNotMovePosition;

    Vector2 touchPlayerObstacleNotMove;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;

        ObstacleNotMovePosition = transform.position;

        touchPlayerObstacleNotMove = ObstacleNotMovePosition - playerPosition;

        if(touchPlayerObstacleNotMove.magnitude > TestPlayerRadius.radiusPlayer + ObstacleNot.ObstacleRadius)
        {
            Destroy(gameObject);
        }
    }
}
