using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Scr_PotatoMine : MonoBehaviour
{
    public GameObject explosion;
    public SpriteRenderer selfSpriteRenderer;
    public Animator selfAnimator;

    public GameObject exploder;

    public float HP;
    public float maxHP;
    public float DMG;

    SpriteRenderer explSpriteRenderer;
    Animator explAnimator;

    public bool armed;

    public UnityEvent attack;

    private bool coroutineStop = false;
    //variables


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        explSpriteRenderer = explosion.GetComponent<SpriteRenderer>();
        explAnimator = explosion.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(coroutineStop == true)
        {
            StopCoroutine(GrowPotatoMine());
            coroutineStop = false;
            selfAnimator.SetBool("Reset", false);
        }

        if(HP <= 0)
        {
            Vector3 positon = transform.position;
            positon.x = 1000;
            positon.y = 1000;
            transform.position = positon;
        }
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
            armed = true;
            selfAnimator.SetBool("isGrown?", true);
            coroutineStop = true;
            yield return null;
        }

    }
    //growth timer, when finished, play the priming animation 

    public void OnTriggerExplosion()
    {
        explSpriteRenderer.enabled = true;
        explAnimator.enabled = true;
    }
    //this WOULD HAVE triggered the explosion animation, while it does that, there is nothing to trigger the explosion due to failure to make the zombies work

    public void OnExplode()
    {
        attack.Invoke();
        exploder.GetComponent<Animator>().enabled = false;
        exploder.GetComponent<SpriteRenderer>().enabled = false;
        Vector3 positon = transform.position;
        positon.x = -1000;
        positon.y = -1000;
        transform.position = positon;
        explSpriteRenderer.enabled = false;
        explAnimator.enabled = false;
        selfAnimator.enabled = false;
        selfSpriteRenderer.enabled = true;
        selfAnimator.SetBool("isExploding?", false);
        selfAnimator.SetBool("isGrown?", false);
        armed = false;
    }
    //this would have applied damage to the zombies on the tile, but due to lack of functional zombies this is only triggered when the potato mine's explosion is manually triggered in the animator

    public void OnDamageTake(float damage)
    {
        

        if (armed == false)
        {
            HP -= damage;
            //apply damage
        }
        if (armed == true)
        {
            selfAnimator.SetBool("isExploding?", true);
        }
    }

    public void OnReset()
    {
        HP = maxHP;
        Vector3 positon = transform.position;
        positon.x = -1.84f;
        positon.y = -1.03f;
        transform.position = positon;
        selfAnimator.SetBool("Reset", true);
        selfAnimator.enabled = true;
    }
}
