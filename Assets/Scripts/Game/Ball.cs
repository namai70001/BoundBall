using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float maxLife;

    [System.NonSerialized]
    public float currentLife;

    [SerializeField]
    private float gravity;

    [SerializeField]
    private float boundPower;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        move -= new Vector3(0, gravity * Time.deltaTime);

        transform.position += move * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float lineAngle = collision.gameObject.transform.localRotation.z + 90;
        Vector2 boundDirection = new Vector2(Mathf.Cos(lineAngle),Mathf.Sin(lineAngle));

        move = boundDirection * boundPower;
    }

    public float GetMaxLife()
    {
        return maxLife;
    }
}
