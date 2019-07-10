using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove: ObstacleNot
{
    public static float move = 0.5f;
    public static int returnTime = 10;
    public static int returnTimeCounter = 0;
    public static bool returnCheck = false;
}

public class ObstacleMoveY : MonoBehaviour
{

    ObstacleMove obstacleMoveY = new ObstacleMove();

    GameObject player;

    Vector2 playerPosition;

    Vector2 ObstacleMoveYPosition;

    Vector2 touchPlayerObstacleMoveY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();


    }

    public void Move()
    {
        ObstacleMove.returnTimeCounter++;

        if (ObstacleMove.returnTimeCounter >= ObstacleMove.returnTime)
        {
            if (ObstacleMove.returnCheck == false)
            {
                ObstacleMove.returnCheck = true;
            }
            else
            {
                ObstacleMove.returnCheck = false;
            }

            ObstacleMove.returnTimeCounter = 0;

        }
        if (ObstacleMove.returnCheck == true)
        {
            transform.Translate(0, -ObstacleMove.move, 0);
        }
        else
        {
            transform.Translate(0, ObstacleMove.move, 0);
        }

        playerPosition = player.transform.position;

        ObstacleMoveYPosition = transform.position;

        touchPlayerObstacleMoveY = touchPlayerObstacleMoveY - playerPosition;

        if (touchPlayerObstacleMoveY.magnitude > TestPlayerRadius.radiusPlayer + ObstacleMove.ObstacleRadius)
        {
            Destroy(gameObject);
        }


    }

}