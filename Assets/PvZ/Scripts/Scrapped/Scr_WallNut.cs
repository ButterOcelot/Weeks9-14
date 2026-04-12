using UnityEngine;

public class Scr_WallNut : MonoBehaviour
{

    public float HP;
    public float maxHP;
    public float DMGTaken;
    public Animator animator;
    //variable

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("HP", HP);
    }
    //change the idle animation depending on hp

    public void OnDamageTake(float damage)
    {
        HP -= damage;
    }
    //apply damage to the wallnut
}
