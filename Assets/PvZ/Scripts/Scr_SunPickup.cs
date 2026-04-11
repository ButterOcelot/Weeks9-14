using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_SunPickup : MonoBehaviour
{

    private Vector3 position;
    public float speed;
    private float acceleration = -0.1f;
    public float landingY;
    public bool isSpawned;
    public SpriteRenderer sprite;

    public GameObject player;
    private float decayTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        int tempNumber = Random.Range(1, 6);
        if (tempNumber == 1 && isSpawned == false)
        {
            landingY = -2.522f;
        }
        if (tempNumber == 2 && isSpawned == false)
        {
            landingY = -1.089f;
        }
        if(tempNumber == 3 && isSpawned == false)
        {
            landingY = 0.3497f;
        }
        if (tempNumber == 4 && isSpawned == false)
        {
            landingY = 1.797f;
        }
        if(tempNumber == 5 && isSpawned == false)
        {
            landingY = 3.241f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePosition);

        if (sprite.bounds.Contains(worldMousePos) == true)
        {
            player.isOverSun = true;
            if(player.clickedCount%2 = 0)
            {
               Destroy(gameObject);
            }
        }
        else
        {
            player.isOverSun = false;
        }


            position = transform.position;
        if(position.y > landingY)
        {
            position.y += speed * Time.deltaTime;
            if (speed > -3)
            {
                speed += acceleration;
            }
        }
        transform.position = position;

        if(position.y <= landingY)
        {
            decayTimer += Time.deltaTime;
            if(decayTimer >= 20)
            {
                Destroy(gameObject);
            }
        }
    }
}
