using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;

    private float directionX = 1;
    private float directionY = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speedX * directionX * Time.deltaTime, speedY * directionY * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        directionX *= -1;
        directionY *= -1;
    }
}
