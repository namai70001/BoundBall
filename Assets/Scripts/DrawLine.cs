using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.ObjectPool;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject hasuPrefab;
    public float lineLength = 0.2f; //線の長さ
    public float lineWidth = 0.1f;  //線の幅
    Vector3 startPos;
    Vector3 LineStartPos;
    Vector3 endPos;
    int cubecnt;

    private Vector3 touchPos;

    void Start()
    {
        //ObjectPoolManager.Instance.CreatePool("cube",1);

    }

    void Update()
    {
        drawLine();
    }

    void drawLine()
    {

        if (Input.GetMouseButtonDown(0))
        {
            cubecnt = 0;
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
            LineStartPos = touchPos;
        }

        if (Input.GetMouseButton(0))
        {

            startPos = touchPos;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            //ObjectPoolManager.Instance.GetObject("cube");

            if ((endPos - startPos).magnitude > lineLength)
            {
                //ObjectPoolManager.Instance.GetObject("cube");
                //GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                GameObject obj = ObjectPoolManager.Instance.GetObject("cube");
                /*linePrefab.transform.position = (startPos + endPos) / 2;
                linePrefab.transform.right = (endPos - startPos).normalized;

                linePrefab.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

                linePrefab.transform.parent = this.transform;
                */
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;

                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

                obj.transform.parent = this.transform;

                touchPos = endPos;
                cubecnt++;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject hasu = ObjectPoolManager.Instance.GetObject("kari_hasu");
            //GameObject hasu = Instantiate(hasuPrefab, transform.position, transform.rotation) as GameObject;

            Vector2 Line = new Vector2((endPos.x - LineStartPos.x),(endPos.y - LineStartPos.y));

            hasu.transform.position = new Vector3(LineStartPos.x + 1, LineStartPos.y, 0);
            hasu.transform.localScale = new Vector3(cubecnt, 1, 10);

            float angle = Mathf.Atan2(Line.y, Line.x);

            angle *= 180;
            angle /= Mathf.PI;
            hasu.transform.Rotate(new Vector3(0, 0, angle));
        }
    }
}

