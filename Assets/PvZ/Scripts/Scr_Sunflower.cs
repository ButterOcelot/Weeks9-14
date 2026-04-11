using UnityEngine;

public class Scr_Sunflower : MonoBehaviour
{
    public float HP;
    public float maxHP;
    public float DMG;
    public float DMGTaken;

    public float sunTimer;

    public GameObject sun;

    Vector3 spawnPos;

    public Animator animator;

    Vector3 sunLanding;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sunLanding = transform.position;
        spawnPos = transform.position;
        spawnPos.y += 2.5f;
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
    }

    public void spawnSun()
    {
        GameObject sunPickup = Instantiate(sun, spawnPos, Quaternion.identity);
        Scr_SunPickup script = sunPickup.GetComponent<Scr_SunPickup>();
        script.landingY = sunLanding.y;
        SpriteRenderer sunSprite = sunPickup.GetComponent<SpriteRenderer>();
        sunSprite.sortingOrder = 150;
    }

    public void endProduceAnim()
    {
        animator.SetBool("IsProducingSun?", false);
    }
}
