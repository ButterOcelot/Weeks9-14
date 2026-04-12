using UnityEngine;
using UnityEngine.Events;


public class Scr_PotatomineExplode : MonoBehaviour
{
    public GameObject potatomine;

    Animator animPotatoMine;
    SpriteRenderer spritePotatoMine;

    public UnityEvent OnExplode;
    //Variables
    


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
    //this is triggered at the start of the potatomine exploding, hiding the main sprite so that it disapears before the explosion sprite finishes.

    public void OnExplodeEnd()
    {
        OnExplode.Invoke();
    }
    //this invokes the potatomine to destroy itself and WOULD have applied damage to the zombie that triggered it
}
