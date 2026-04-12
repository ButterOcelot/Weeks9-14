using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Scr_Zombie : MonoBehaviour
{
    public float HP;
    public float Speed;
    public float DMG;
    public bool Eating;

    public float armorDegrade1;
    public float armorDegrade2;
    public float armorDegrade3;

    public Sprite Armor1;
    public Sprite Armor2;
    public Sprite Armor3;

    public List<Sprite> possibleArmor = new List<Sprite>();

    public GameObject armor;
    public Animator animator;

    public string ID;

    public UnityEvent OnEat;
    //variables

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ID == "basic")
        {
            HP = 100;
            armorDegrade1 = 0;
            armorDegrade2 = 0;
            armorDegrade3 = 0;
        }
        if (ID == "cone")
        {
            HP = 560;
            armorDegrade1 = 415;
            armorDegrade2 = 315;
            armorDegrade3 = 210;
            Armor1 = possibleArmor[0];
            Armor2 = possibleArmor[1];
            Armor3 = possibleArmor[2];
        }
        if (ID == "bucket")
        {
            HP = 1290;
            armorDegrade1 = 1000;
            armorDegrade2 = 650;
            armorDegrade3 = 325;
            Armor1 = possibleArmor[3];
            Armor2 = possibleArmor[4];
            Armor3 = possibleArmor[5];
        }
        //sets the hp, armor, and armor degrade values depending on what zombie type it is
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
        //delete when hp is 0 or lower

        Vector3 position = transform.position;

        animator.SetFloat("HP", HP);

        if (HP > armorDegrade1 && ID != "basic")
        {
            armor.GetComponent<SpriteRenderer>().sprite = Armor1;
        }
        if (HP > armorDegrade2 && HP <= armorDegrade1 && ID != "basic")
        {
            armor.GetComponent<SpriteRenderer>().sprite = Armor2;
        }
        if (HP > armorDegrade3 && HP <= armorDegrade2 && ID != "basic")
        {
            armor.GetComponent<SpriteRenderer>().sprite = Armor3;
        }
        //change the armor sprite depending on HP

    }
    
    public void OnDamageTake(float damage)
    {
        Debug.Log(damage);
        HP -= damage;
    }
    //take damage

}
