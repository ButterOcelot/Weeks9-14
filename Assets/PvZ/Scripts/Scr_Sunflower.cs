using UnityEngine;

public class Scr_Sunflower : MonoBehaviour
{


    public float HP;
    public float maxHP;
    
    public float DMGTaken;

    public float sunTimer;

    public GameObject sun;

    Vector3 spawnPos;

    public Animator animator;

    Vector3 sunLanding;
    //variables



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sunLanding = transform.position;
        spawnPos = transform.position;
        spawnPos.y += 2.5f;
        //set up where the sun spawned by the sunflower will land
    }

    // Update is called once per frame
    void Update()
    {
        sunTimer += Time.deltaTime;
        if (sunTimer >= 34)
        {
            sunTimer = 0;
            animator.SetBool("IsProducingSun?", true);
        }
        //timer for how long the sunflower takes to produce sun. When done, trigger the animation for producing sun
    }

    public void spawnSun()
    {
        GameObject sunPickup = Instantiate(sun, spawnPos, Quaternion.identity);
        Scr_SunPickup script = sunPickup.GetComponent<Scr_SunPickup>();
        script.isSpawned = true;
        script.landingY = sunLanding.y;
        SpriteRenderer sunSprite = sunPickup.GetComponent<SpriteRenderer>();
        sunSprite.sortingOrder = 150;
        //spawn a sun pickup when invoked
    }

    public void endProduceAnim()
    {
        animator.SetBool("IsProducingSun?", false);
        //swap back to the idle animation after producing a sun pickup
    }

    public void OnDamageTake(float damage)
    {
        HP -= damage;
        //apply damage
    }

}
