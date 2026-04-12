using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class Scr_Player : MonoBehaviour
{
    //int clickedCount;

    public float sun;
    public GameObject plantID;
    public GameObject sunCounter;

    public GameObject potatomineCooldown;
    public Slider potatomineCooldownController;

    bool canPlantPMine = true;

    public GameObject potatomine;
    public GameObject sunPickup;

    public Vector2 worldMousePos;
    int clickedCount;

    public UnityEvent potatoreset;

    //variables


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        TextMeshProUGUI sunCounterText = sunCounter.GetComponent<TextMeshProUGUI>();

        string sunTotal = sun.ToString();
        sunCounterText.text = sunTotal;
        //updates the sun counter when the player collects or uses sun
    }

   
    public void setPlantIDPotatoMine()
    {
        if (sun >= 500 && canPlantPMine == true)
        {
            potatoreset.Invoke();
            OnPlantedPotatoMine();
            sun -= 500;
        }

        else
        {
            Debug.Log("You dont have enough sun!");
        }
        //when the player clicked on the seeds for potato mines, set the plant string for planting and remove the needed sun, or if they cant afford it tell them they cant
    }


    public void OnPlantedPotatoMine()
    {
        StartCoroutine(PotatoMineCooldown());
        canPlantPMine = false;
        //if a potato mine is planted, start the cooldown on the seeds
    }

    IEnumerator PotatoMineCooldown()
    {
        float t = 20;

        while (t > 0)
        {
            t -= Time.deltaTime;
            potatomineCooldownController.value = t;
            potatomineCooldown.GetComponent<Image>().fillAmount = (potatomineCooldownController.value/20);
            if (t == 0)
            {
                canPlantPMine = true;
                yield break;
            }
            yield return null;
        }
        //have a timer that acts as a cooldown for the potatomine seeds, and visualy indicates this over the seedpacket
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    //tracks the player's mouse movment via player input actions

    public void OnClick(InputAction.CallbackContext context)
    {
        sunPickup = GameObject.Find("SunPickup(Clone)");
        clickedCount += 1;

        if (sunPickup != null && sunPickup.GetComponent<SpriteRenderer>().bounds.Contains(worldMousePos) == true && context.performed == true && clickedCount % 2 == 0)
        {
            SunGrab();
            Destroy(sunPickup);
        }
        //if the player clicks on a sun pickup, delete it and trigger the sun grab event on it
    }



    public void SunGrab()
    {
        sun += 25;
    }
    //add 25 sun to the player's sun total
}
