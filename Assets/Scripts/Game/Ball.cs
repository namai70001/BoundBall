using Framework.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float maxLife;
    public float MaxLife { get { return maxLife; } }

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
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        move -= new Vector3(0, gravity * Time.deltaTime);

        transform.position += move * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
            ObjectPoolManager.Instance.DeleteObject(collision.gameObject);
    }
}
