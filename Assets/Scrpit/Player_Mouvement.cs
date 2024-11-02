using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public  int bat_num = 0;

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
    }

    void Move()
    {
        // Récupère l'input horizontal (flèches ou A/D)
        float moveInput = Input.GetAxis("Horizontal");

        // Applique la vitesse lissée au mouvement horizontal tout en gardant la vitesse verticale
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            // Calculate the direction from the spotlight to the mouse
        if (rb.velocity.x >= 0)
        {
            is_flipped = false;
        }
        else
        {
            is_flipped = true;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(moveInput));
        if (rb.transform.position.y < -4)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Vérifie si le joueur touche le sol
        {
            isGrounded = true; // Le joueur est au sol
        }
        if (collision.gameObject.CompareTag("kollectible"))
        {
            update_bat_num();
        }
        if (collision.gameObject.CompareTag("fantome"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Vérifie si le joueur quitte le sol
        {
            isGrounded = false; // Le joueur n'est plus au sol
        }
    }

    public void update_bat_num()
    {
        bat_num++;
    }
}
