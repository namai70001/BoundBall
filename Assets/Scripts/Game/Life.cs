using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Ball player;
    private Image image;    

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = player.currentLife / player.MaxLife;
    }
}
