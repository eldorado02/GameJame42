using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the inspector
    public float projectileSpeed = 10f; // Speed of the projectile
    private SpriteRenderer player;

    void Start()
    {
        player = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1)) // 1 is for right mouse button
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Create a projectile instance at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        
        // Set the projectile's velocity to the right
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (player.flipX)
                rb.velocity = Vector2.right * projectileSpeed; // Fire to the right
            else
                rb.velocity = Vector2.left * projectileSpeed; // Fire to the right
        }
    }
}
