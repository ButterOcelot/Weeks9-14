using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Scr_PotatoMine : MonoBehaviour
{
    public GameObject explosion;
    public SpriteRenderer selfSpriteRenderer;
    public Animator selfAnimator;

    public GameObject colider;

    public float HP;
    public float maxHP;
    public float DMG;
    public float DMGTaken;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGrowth()
    {
        StartCoroutine(GrowPotatoMine());
    }


    IEnumerator GrowPotatoMine()
    {
        float t = 0;

        while (t < 14)
        {
            t += Time.deltaTime;
            yield return null;
        }
        
        if(t >= 14)
        {
            selfAnimator.SetBool("isGrown?", true);
        }

    }

    public void OnTriggerExplosion()
    {
        SpriteRenderer explSpriteRenderer = explosion.GetComponent<SpriteRenderer>();
        Animator explAnimator = explosion.GetComponent<Animator>();

        explSpriteRenderer.enabled = true;
        explAnimator.enabled = true;
    }

    public void OnExplode()
    {
        Destroy(gameObject);
    }
}
