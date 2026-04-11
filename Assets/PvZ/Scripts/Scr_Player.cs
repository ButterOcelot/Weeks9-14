using UnityEngine;
using TMPro;

public class Scr_Player : MonoBehaviour
{
    public float sun;
    public string plantID;
    public GameObject sunCounter;

    public GameObject peashooterSeedsBG;
    public GameObject peashooterSeedsCorner;
    public GameObject peashooterSeedsPlant;

    public GameObject potatomineBG;
    public GameObject potatomineCorner;
    public GameObject potatominePlant;


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
}
