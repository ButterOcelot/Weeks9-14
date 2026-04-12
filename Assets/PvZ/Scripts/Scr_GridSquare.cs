using UnityEngine;

public class Scr_GridSquare : MonoBehaviour
{

    public GameObject player;
    public Scr_Player playerScript;
    public SpriteRenderer spriteRenderer;
    //variables

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GameObject.Find("Player");
        //Scr_Player playerScript = player.GetComponent<Scr_Player>();
        
        //this didnt work, it was supposed to grab the player and player script, but it wouldnt work
    }

    // Update is called once per frame
    void Update()
    {
        //bool isHovered = spriteRenderer.bounds.Contains(playerScript.worldMousePos);
        //if (isHovered == true)
        //{
        //    Color tempColor = spriteRenderer.color;
        //    tempColor.a = 0.5f;
        //    spriteRenderer.color = tempColor;
        //}
        //if (isHovered == false)
        //{
        //    Color tempColor = spriteRenderer.color;
        //    tempColor.a = 0f;
        //    spriteRenderer.color = tempColor;
        //}

        //this would've highlighted a grid square when the player hovered over it, but i couldnt get it to work
    }
}
