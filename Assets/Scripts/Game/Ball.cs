using Framework.ObjectPool;
using Game.StageManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private const string SCORE_KEY = "score";

    [SerializeField]
    private float maxLife;
    public float MaxLife { get { return maxLife; } }

    [System.NonSerialized]
    public float currentLife;

    [SerializeField]
    private float itemHealLife;

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
        else if (collision.gameObject.tag == "Over")
            GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Item")
        {
            currentLife += itemHealLife;
            ObjectPoolManager.Instance.DeleteObject(collision.gameObject);
        }

        if(collision.gameObject.tag == "Stage")
        {
            StageController.Instance.NextStage();
        }
    }

    private void Heal()
    {
        currentLife += itemHealLife;
        if(currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    private void GameOver()
    {
    }
}
