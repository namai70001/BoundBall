using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.ObjectPool;

public class DrawLine : MonoBehaviour
{
    private const string cubePath = "Prefab/cube";
    private const string linePath = "Prefab/Line";

    public float lineLength = 0.2f; //線の長さ
    public float lineWidth = 0.1f;  //線の幅

    private Vector3 lineBaseScale = new Vector3(0.03f,0.03f,0);
    Vector3 startPos;
    Vector3 LineStartPos;
    Vector3 endPos;
    int cubecnt;

    private Vector3 touchPos;

    public  Ball player;

    void Start()
    {
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

            if ((endPos - startPos).magnitude > lineLength)
            {
                GameObject obj = ObjectPoolManager.Instance.GetObject(cubePath);

                obj.transform.parent = transform;

                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;

                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

                obj.transform.parent = this.transform;

                player.currentLife -= 1;

                touchPos = endPos;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            foreach(Transform trans in transform)
            {
                ObjectPoolManager.Instance.DeleteObject(trans.gameObject);
            }

            GameObject line = ObjectPoolManager.Instance.GetObject(linePath);

            Vector2 linePosition = (LineStartPos + endPos) * 0.5f;
            float lineScale = (LineStartPos - endPos).magnitude;
            float lineAngle = GetAim(LineStartPos , endPos);

            line.transform.position = new Vector3(linePosition.x, linePosition.y, 1);
            line.transform.localScale = new Vector3(lineScale * lineBaseScale.x, lineScale * lineBaseScale.y, 1);
            line.transform.Rotate(new Vector3(0, 0, lineAngle - line.transform.rotation.z));

            line.transform.parent = transform;
        }
    }

    private float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}

