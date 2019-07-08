using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    GameObject player;

    float scorePlayerY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayerY = player.transform.position.y;

        GetComponent<Text>().text = "現在" + scorePlayerY.ToString() + "m";
    }
}
