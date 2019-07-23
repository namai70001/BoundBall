using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject player;

    int scorePlayerY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayerY = (int)player.transform.position.y;

        GetComponent<Text>().text = "現在" + scorePlayerY.ToString();
    }
}
