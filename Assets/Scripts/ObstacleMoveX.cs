using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveX : MonoBehaviour
{

    ObstacleMove obstacleMoveX = new ObstacleMove();

    GameObject player;

    Vector2 playerPosition;

    Vector2 ObstacleMoveXPosition;

    Vector2 touchPlayerObstacleMoveX;

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

        if (ObstacleMove.returnCheck == true)
        {
            transform.Translate(ObstacleMove.move, 0, 0);
        }
        else
        {
            transform.Translate(ObstacleMove.move, 0, 0);
        }


        playerPosition = player.transform.position;

        ObstacleMoveXPosition = transform.position;

        touchPlayerObstacleMoveX = ObstacleMoveXPosition - playerPosition;

        if (touchPlayerObstacleMoveX.magnitude > TestPlayerRadius.radiusPlayer + ObstacleMove.ObstacleRadius)
        {
            Destroy(gameObject);
        }



    }
}
