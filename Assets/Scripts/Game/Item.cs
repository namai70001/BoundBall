using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerRadius   // 適当に値入れてるやつ
{
    public static float radiusPlayer = 1.0f;
}

public class ItemPatternA
{
    public static float recovery = 10.0f;
    public static float radiusItem = 0.5f;
    public static bool get = false;
}

public class Item : MonoBehaviour
{

    GameObject player;

    Vector2 touchPlayerItem;

    Vector2 itemPosition;

    Vector2 playerPosition;

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ball");

        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        playerPosition = player.transform.position;

        itemPosition = transform.position;

        touchPlayerItem = itemPosition - playerPosition;

        if (touchPlayerItem.magnitude < TestPlayerRadius.radiusPlayer + ItemPatternA.radiusItem)
        {

            ItemPatternA.get = true;
            
            if (ItemPatternA.get == true)
            {
                slider.value += ItemPatternA.recovery;
                ItemPatternA.get = false;
            }
        }

    }
}
