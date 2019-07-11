using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y)
            transform.position += new Vector3(0, player.transform.position.y - transform.position.y, 0);
    }
}
