using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Scr_Peashooter : MonoBehaviour
{
    public float HP;
    public float maxHP;
    public float DMGTaken;
    public GameObject pea;
    public GameObject peaSpawnLocation;
    public GameObject rangeObject;
    public bool zombieInLane;
    public Animator animator;
    public GameObject target;
    private SpriteRenderer range;
    //variables


    //lane zombie spawns -4.10948 -2.696043 -1.3 0.11 1.65352

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        range = rangeObject.GetComponent<SpriteRenderer>();
        //get the sprite from the range object
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Zombie(Clone)");
        GameObject targetPos = target.transform.GetChild(0).gameObject;
        //find the zombie objects

        if (range.bounds.Contains(targetPos.transform.position) == true)
        {
            zombieInLane = true;
        }
        else
        {
            zombieInLane = false;
        }        
        
        if (zombieInLane == true)
        {
            animator.SetBool("IsAttacking?", true);
        }
        if (zombieInLane == false)
        {
            animator.SetBool("IsAttacking?", false);
        }
        //if zombies are in the lane, enable the animation for shooting, or dont if there are no zombies

    }

    public void OnDamageTake(float damage)
    {
        HP -= damage;
        //apply damage
    }

    public void OnShootPea()
    {
        GameObject shotPea = Instantiate(pea, peaSpawnLocation.transform.position, Quaternion.identity);
        //when invoked, spawn a pea
    }
}
