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
    public string plantID;
    public GameObject sunCounter;

    public GameObject peashooterCooldown;
    public Slider peashooterSeedsCooldown;

    public GameObject sunflowerCooldown;
    public Slider sunflowerSeedsCooldown;

    public GameObject wallnutCooldown;
    public Slider wallnutSeedsCooldown;

    public GameObject potatomineCooldown;
    public Slider potatomineCooldownController;

    public GameObject bonkchoyCooldown;
    public Slider bonkchoySeedsCooldown;

    bool canPlantPeaShtr = true;
    bool canPlantSunFlw = true;
    bool canPlantWallnut = true;
    bool canPlantPMine = true;
    bool canPlantBchoy = true;

    public GameObject sunPickup;

    Vector2 worldMousePos;
    int clickedCount;


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
        if (sun >= 100 && canPlantPeaShtr == true)
        {
            plantID = "peashooter";
            sun -= 100;
        }

        else
        {
            Debug.Log("You dont have enough sun!");
        }
    }

    public void setPlantIDSunFlower()
    {
        if (sun >= 50 && canPlantSunFlw == true)
        {
            plantID = "sunflower";
            sun -= 50;
        }

        else
        {
            Debug.Log("You dont have enough sun!");
        }
    }

    public void setPlantIDWallNut()
    {
        if (sun >= 50 && canPlantWallnut == true)
        {
            plantID = "wallnut";
            sun -= 50;
        }

        else
        {
            Debug.Log("You dont have enough sun!");
        }
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

    public void setPlantIDBonkChoy()
    {
        if (sun >= 150 && canPlantBchoy == true)
        {
            plantID = "bonkchoy";
            sun -= 150;
        }

        else
        {
            Debug.Log("You dont have enough sun!");
        }
    }

    //public void OnPlantedPeashooter()
    //{
    //    StartCoroutine(PeashooterCooldown());
    //    canPlantPeaShtr = false;

    //}

    //IEnumerator PeashooterCooldown()
    //{
    //    float t = 20;

    //    while (t > 0)
    //    {
    //        t -= Time.deltaTime;
    //        peahsooterCooldownController.value = t;
    //        peahsooterCooldown.GetComponent<Image>().fillAmount = (peahsooterCooldownController.value / 20);
    //        if (t == 0)
    //        {
    //            canPlantPeaShtr = true;
    //            yield break;
    //        }
    //        yield return null;
    //    }

    //}

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

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        sunPickup = GameObject.Find("SunPickup(Clone)");
        clickedCount += 1;

        if (sunPickup != null && sunPickup.GetComponent<SpriteRenderer>().bounds.Contains(worldMousePos) == true && context.performed == true && clickedCount % 2 == 0)
        {
            SunGrab();
            Destroy(sunPickup);
        }
    }



    public void SunGrab()
    {
        sun += 25;
    }

}
