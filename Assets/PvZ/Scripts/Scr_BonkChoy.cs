using UnityEngine;

public class Scr_BonkChoy : MonoBehaviour
{

    public Animator animator;
    public float HP;
    public float maxHP;
    public float DMGTaken;
    public float DMG;
    public bool isZombieInFront;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isZombieInFront == true)
        {
            animator.SetBool("InFront?", true);
        }
        else
        {
            animator.SetBool("InFront?", false);
        }
    }

    public void OnDamageTake()
    {

    }
}
