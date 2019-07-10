using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestScripts : MonoBehaviour
{
    public float testPaintLongth = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        testPaintLongth = 1000.0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
            testPaintLongth--;
        }
        /*if (Input.GetKey(KeyCode.A))
        {
            Item.get = true;
        }

        if (Item.get == true)
        {
            testPaintLongth += Item.recovery;
            Item.get = false;
        }*/

    }
}
