using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Scr_Zombie : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public float Speed;
    public float MaxSpeed;
    public float DMG;
    public bool Eating;
    public Sprite Armor1;
    public List<Sprite> possibleArmor = new List<Sprite>();

    public GameObject armor;
    public Animator animator;

    public string ID;
    public SpriteRenderer spriteRenderer;

    public GameObject target;

    public UnityEvent OnEat;

    bool timerCheck = false;
    float timer = 0;
    //variables

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (ID == "cone")
        {
            Armor1 = possibleArmor[0];
        }
        if (ID == "bucket")
        {
            Armor1 = possibleArmor[1];
        }
        //sets the hp, armor, and armor degrade values depending on what zombie type it is
    }

    // Update is called once per frame
    void Update()
    {
        if(timerCheck == true)
        {
            timer += Time.deltaTime;
            if(timer >= 10)
            {
                timerCheck = false;
                timer = 0;
                HP = MaxHP;
                Vector3 positon2 = transform.position;
                positon2.x = 12.15f;
                positon2.y = -1.05543f;
                transform.position = positon2;
            }
        }

        if (spriteRenderer.bounds.Contains(target.transform.position))
            {
            Speed = 0f;
            animator.SetBool("IsEating",true);
            
        }
        else
        {
            Speed = MaxSpeed;
            animator.SetBool("IsEating", false);
        }

        Vector3 positon = transform.position;
        positon.x -= Speed*Time.deltaTime;
        transform.position = positon;

        if(HP <= 0)
        {
            animator.SetBool("IsEating", false);
            animator.SetFloat("HP", 0);
        }
        //delete when hp is 0 or lower

    }
    
    public void eatinganim()
    {
        
        OnEat.Invoke();
    }

    public void OnDamageTake(float damage)
    {
        HP -= damage;
    }
    //take damage

    public void OnDeath()
    {
        HP = MaxHP;
        Vector3 positon = transform.position;
        positon.x = 1000;
        positon.y = 1000;
        transform.position = positon;
        animator.SetFloat("HP", 100);
        timerCheck = true;
        Eating = false;
    }

}
