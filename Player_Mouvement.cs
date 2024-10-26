using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Vitesse maximale de déplacement
    public float acceleration = 2f;       // Vitesse d'accélération
    public float jumpForce = 10f;         // Force de saut
    private Rigidbody2D rb;
    private bool isGrounded;
    private float currentSpeed = 0f;      // Vitesse actuelle pour un lissage progressif

    private bool    is_flipped = false;

    public  SpriteRenderer  player;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (is_flipped)
            player.flipX = false;
        else
            player.flipX = true;
        Move();
        Jump();
    }

    void Move()
    {
        // Récupère l'input horizontal (flèches ou A/D)
        float moveInput = Input.GetAxis("Horizontal");

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z to 0 for 2D

        // Calcul de la vitesse actuelle avec accélération et interpolation pour lisser
        currentSpeed = Mathf.Lerp(currentSpeed, moveInput * moveSpeed, Time.deltaTime * acceleration);

        // Applique la vitesse lissée au mouvement horizontal tout en gardant la vitesse verticale
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

            // Calculate the direction from the spotlight to the mouse
        if (rb.velocity.x >= 0)
        {
            is_flipped =false;
        }
        else
        {
            is_flipped = true;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(moveInput));
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // Vérifie si le joueur appuie sur le bouton de saut
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Applique une force pour sauter
            isGrounded = false; // Le joueur n'est plus au sol après le saut
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Vérifie si le joueur touche le sol
        {
            isGrounded = true; // Le joueur est au sol
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Vérifie si le joueur quitte le sol
        {
            isGrounded = false; // Le joueur n'est plus au sol
        }
    }
}
