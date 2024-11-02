using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{
    public float jumpForce = 10f;       // Force du saut
    public LayerMask groundLayer;       // Layer du sol
    private Rigidbody2D rb;             // Référence au Rigidbody2D du parent
    private bool isGrounded;

    void Start()
    {
        // Accède au Rigidbody2D du parent
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();

        // Si on est au sol et que le joueur appuie sur la touche de saut
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void CheckGround()
    {
        // Vérifie si le collider de l’objet enfant touche le sol
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer);
        isGrounded = collider != null;
    }

    void Jump()
    {
        // Applique la force de saut au Rigidbody2D du parent
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}

