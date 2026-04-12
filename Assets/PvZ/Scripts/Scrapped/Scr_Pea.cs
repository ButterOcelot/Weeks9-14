using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Scr_Pea : MonoBehaviour
{
    float speed = 5.2f;
    float DMG = 20;
    public GameObject target;
    public SpriteRenderer targetSprite;
    //variables

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Zombie(Clone)");
        targetSprite = target.GetComponent<SpriteRenderer>();
        //finds a zombiie and gets it's sprite

        if (targetSprite.bounds.Contains(transform.position))
        {
            GameObject tempGameObj = GameObject.Find("Zombie(Clone)");
            tempGameObj.GetComponent<Scr_Zombie>().OnDamageTake(DMG);
            Destroy(gameObject);
            //if the pea is inside a zombie, delete the pea and trigger the zombie's damage event
        }

        Vector3 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
        if(position.x > 20.11)
        {
            Destroy(gameObject);
        }
        //move to the right, if you go beyond the lawn, delete the pea to prevent them from building up.
    }
}
