using UnityEngine;
using UnityEngine.Events;


public class Scr_PotatomineExplode : MonoBehaviour
{
    public GameObject potatomine;

    Animator animPotatoMine;
    SpriteRenderer spritePotatoMine;

    public UnityEvent OnExplode;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animPotatoMine = potatomine.GetComponent<Animator>();
        spritePotatoMine = potatomine.GetComponent<SpriteRenderer>();
        //grabs the animator and sprite renderer of the potato mine

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void OnExplodeStart()
    {
        animPotatoMine.enabled = false;
        spritePotatoMine.enabled = false;
    }

    public void OnExplodeEnd()
    {
        OnExplode.Invoke();
    }
}
