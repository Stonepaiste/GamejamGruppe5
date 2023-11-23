using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // højden når spilleren er bøjet
    public float crouchingHeight = 2f;
    
    // Den normale højde for spilleren
    public float playerHeight = 3.8f;

    private bool isCrouching = false;

    // Hvor hurtig playeren skal gå når man croucher
    public float crouchSpeed = 6f;

    // Tid det tager for en glidende overgang mellem crouch og normal
    public float crouchSmoothTime = 0.5f;

    public float speed = 12f;

    public Animator cameraAnim;

    public bool canMove;

    public bool isDead;

    public bool isMoving;

    public float timeUntilRespawn = 5;

    // Tyngdekraft, der påvirker spillerens fald
    public float gravity = -9.81f;

    // Hastighed af fald for spilleren
    Vector3 velocity;

    void Start()
    {
        // Initialiserer CharacterController
        controller = GetComponent<CharacterController>();
        canMove = true;
    }

    void Update()
    {
        handleCrouch();
    }

    void FixedUpdate()
    {
        // Indsamler input fra tastaturet
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Tjekker om spilleren er i bevægelse
        if (x != 0 || z != 0)
            isMoving = true;
        else
            isMoving = false;

        // Beregner bevægelse baseret på hvor playeren kigger
        Vector3 move = transform.right * x + transform.forward * z;

        // Hvis spilleren croucher, bevæger den sig langsommere, ellers med normal hastighed
        if (isCrouching)
        {
            if(canMove)
                controller.Move(move * crouchSpeed * Time.deltaTime);
        }
        else
        {
            if(canMove)
                controller.Move(move * speed * Time.deltaTime);
        }

        // Simulerer tyngdekraft
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void handleCrouch()
    {
        // Bestemmer højden baseret på om spilleren er bøjet eller ej
        float targetHeight = isCrouching ? crouchingHeight : playerHeight;

        // gør at det ser mere smooth ud mellem crouch højden og player højden
        controller.height = Mathf.Lerp(controller.height, targetHeight, 1f - Mathf.Exp(-crouchSmoothTime * Time.deltaTime * 10f));

        // Opdaterer isCrouching baseret på om venstre kontroltast holdes nede
        isCrouching = Input.GetKey(KeyCode.LeftControl);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.GetType() == typeof(CapsuleCollider))
        {
            isDead = true;
            canMove = false;
            cameraAnim.SetBool("IsDead", true);
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeUntilRespawn);
        SceneManager.LoadScene(1);
    }
}
