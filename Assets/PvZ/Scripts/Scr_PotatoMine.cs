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

    public UnityEvent attack;
    //variables


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
    //when the intro animation is done, start the growth timer


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
            yield break;
        }

    }
    //growth timer, when finished, play the priming animation 

    public void OnTriggerExplosion()
    {
        SpriteRenderer explSpriteRenderer = explosion.GetComponent<SpriteRenderer>();
        Animator explAnimator = explosion.GetComponent<Animator>();

        explSpriteRenderer.enabled = true;
        explAnimator.enabled = true;
    }
    //this WOULD HAVE triggered the explosion animation, while it does that, there is nothing to trigger the explosion due to failure to make the zombies work

    public void OnExplode()
    {
        attack.Invoke();
        Destroy(gameObject);
    }
    //this would have applied damage to the zombies on the tile, but due to lack of functional zombies this is only triggered when the potato mine's explosion is manually triggered in the animator

    public void OnDamageTake(float damage)
    {
        HP -= damage;
        //apply damage
    }
}
