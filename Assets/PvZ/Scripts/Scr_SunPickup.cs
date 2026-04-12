using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Scr_SunPickup : MonoBehaviour
{


    private Vector3 position;
    public float speed;
    private float acceleration = -0.1f;
    public float landingY;
    public bool isSpawned;
    public SpriteRenderer sprite;

    private float decayTimer = 0;
    //variables



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GameObject.Find("Player");

        int tempNumber = Random.Range(1, 6);
        if (tempNumber == 1 && isSpawned == false)
        {
            landingY = -2.522f;
        }
        if (tempNumber == 2 && isSpawned == false)
        {
            landingY = -1.089f;
        }
        if (tempNumber == 3 && isSpawned == false)
        {
            landingY = 0.3497f;
        }
        if (tempNumber == 4 && isSpawned == false)
        {
            landingY = 1.797f;
        }
        if (tempNumber == 5 && isSpawned == false)
        {
            landingY = 3.241f;
        }
        //picks a lane to land on
    }

    // Update is called once per frame
    void Update()
    {

        position = transform.position;
        if (position.y > landingY)
        {
            position.y += speed * Time.deltaTime;
            if (speed > -3)
            {
                speed += acceleration;
            }
        }
        transform.position = position;

        if (position.y <= landingY)
        {
            decayTimer += Time.deltaTime;
            if (decayTimer >= 20)
            {
                Destroy(gameObject);
            }
        }
    }
    //the sun will move up before falling down until it lands, and once it lands it has a 20 second timer for the player to grab it before it despawns.
}

   