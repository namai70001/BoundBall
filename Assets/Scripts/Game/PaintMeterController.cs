using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintMeterController : MonoBehaviour
{

    //GameObject paintLongth;

    //TestScripts testScriptPaintLongth;

    [SerializeField] private TestScripts testScript;

    Slider slider;

    [SerializeField] private float maxPaintMater = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {

        //paintLongth = GameObject.Find("TestObject");

        //testScriptPaintLongth = paintLongth.GetComponent<TestScripts>();
        testScript = GetComponent<TestScripts>();


        slider = GetComponent<Slider>();

        slider.maxValue = maxPaintMater;
        slider.value    = maxPaintMater;

    }

    // Update is called once per frame
    void Update()
    {

        //slider.value = testScriptPaintLongth.testPaintLongth;
        slider.value = testScript.testPaintLongth;

    }
}
