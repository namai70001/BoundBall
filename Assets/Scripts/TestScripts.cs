using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class testItem
{
    public static float recovery = 10.0f;
    public static bool get = false;

}

public class TestScripts : MonoBehaviour
{
    public float testPaintLongth = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        // testPaintLongth = 1000.0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
            testPaintLongth--;
        }


        if (Input.GetKey(KeyCode.A))
        {
            testItem.get = true;
        }

        if (testItem.get == true)
        {
            testPaintLongth += testItem.recovery;
            testItem.get = false;
        }

    }
}
