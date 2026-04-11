using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class Scr_Player : MonoBehaviour
{
    int clickedCount;
    public bool isOverSun;

    public float sun;
    public string plantID;
    public GameObject sunCounter;

    //public GameObject peashooterSeedsCooldown;

    public GameObject potatomineCooldown;
    public Slider potatomineCooldownController;
    bool canPlantPMine = true;



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
    }

    public void setPlantIDPeashooter()
    {
        if (sun >= 100)
        {
            plantID = "peashooter";
            sun -= 100;
        }

        else
        {
            Debug.Log("You dont have enough sun!");
        }

            Debug.Log(plantID);

    }

    public void setPlantIDPotatoMine()
    {
        if (sun >= 25 && canPlantPMine == true)
        {
            plantID = "potatomine";
            sun -= 25;
        }

        else
        {
            Debug.Log("You dont have enough sun!");
        }

        

    }

    public void OnPlantedPotatoMine()
    {
        StartCoroutine(PotatoMineCooldown());
        canPlantPMine = false;

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
        
    }

    public void OnSunPickup()
    {
        sun += 25;
        
    }
   
    public void OnClick(InputAction.CallbackContext context)
    {
        clickedCount += 1;

        if (isOverSun == true && context.performed == true && clickedCount%2 == 0)
        {
            OnSunPickup();
        }
    }

}
