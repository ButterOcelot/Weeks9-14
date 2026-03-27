using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Knight : MonoBehaviour
{
    public float speed;
    public AudioSource audioSource;
    public Animator knightAnimator;

    float xMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMovement, 0f, 0f) * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        xMovement = moveDirection.x;

        bool isRunning = xMovement != 0f;

        knightAnimator.SetBool("IsRunning", isRunning);
    }

    public void OnFootStep()
    {
        audioSource.Play();
    }
}
