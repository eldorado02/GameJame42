using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{
    public float jumpForce = 10f;      // Force de saut
    public LayerMask groundLayer;      // Layer du sol pour détecter les collisions

    private Rigidbody2D rb;            // Référence au Rigidbody2D du parent
    private bool isGrounded = false;   // Indicateur si le détecteur touche le sol

    void Start()
    {
        // Obtenir le Rigidbody2D du parent
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        // Si on est au sol et que l'utilisateur appuie sur la touche de saut
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si le détecteur touche le sol
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Vérifie si le détecteur quitte le contact avec le sol
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        // Appliquer la force de saut au Rigidbody2D du parent
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}


