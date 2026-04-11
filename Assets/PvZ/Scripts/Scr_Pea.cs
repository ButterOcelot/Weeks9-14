using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Scr_Pea : MonoBehaviour
{
    float speed = 5.2f;
    float DMG = 20;


    public List<GameObject> targetObjs = new List<GameObject>();
    public List<SpriteRenderer> targets = new List<SpriteRenderer>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < targetObjs.Count; i++)
        {
            targets[i] = targetObjs[i].GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0;  i < targets.Count; i++)
        {
            if (targets[i].bounds.Contains(transform.position))
            {
                GameObject tempGameObj = GameObject.Find(targetObjs[i].name);
                tempGameObj.GetComponent<Scr_Zombie>().OnDamageTake(DMG);
                Destroy(gameObject);
            }
        }

        Vector3 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
        if(position.x > 20.11)
        {
            Destroy(gameObject);
        }
    }
}
