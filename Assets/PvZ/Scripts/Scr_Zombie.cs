using UnityEngine;
using UnityEngine.Events;

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

    public GameObject armor;
    public Animator animator;

    private bool isBasic;

    public UnityEvent OnEat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(armor == null)
        {
            isBasic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 position = transform.position;

        animator.SetFloat("HP", HP);

        if (HP > armorDegrade1 && isBasic == false)
        {
            armor.GetComponent<SpriteRenderer>().sprite = Armor1;
        }
        if (HP > armorDegrade2 && HP <= armorDegrade1 && isBasic == false)
        {
            armor.GetComponent<SpriteRenderer>().sprite = Armor2;
        }
        if (HP > armorDegrade3 && HP <= armorDegrade2 && isBasic == false)
        {
            armor.GetComponent<SpriteRenderer>().sprite = Armor3;
        }
        if (HP <= armorDegrade3 && isBasic == false)
        {
            armor.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    
    public void OnDamageTake(float damage)
    {
        Debug.Log(damage);
        HP -= damage;
    }

}
