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
    public List<GameObject> targets = new List<GameObject>();

    private SpriteRenderer range;


    //lane zombie spawns -4.10948 -2.696043 -1.3 0.11 1.65352

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        range = rangeObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < targets.Count; i++)
        {
            GameObject tempStorage = targets[i];
            GameObject tempTarget = tempStorage.transform.GetChild(0).gameObject;


            if (range.bounds.Contains(tempTarget.transform.position) == true)
            {
                zombieInLane = true;
            }
            else
            {
                zombieInLane = false;

            }
        }        

        if (zombieInLane == true)
        {
            animator.SetBool("IsAttacking?", true);
        }
        if (zombieInLane == false)
        {
            animator.SetBool("IsAttacking?", false);
        }
    }

    public void OnDamageTake()
    {

    }

    public void OnShootPea()
    {
        GameObject shotPea = Instantiate(pea, peaSpawnLocation.transform.position, Quaternion.identity);
    }
}
