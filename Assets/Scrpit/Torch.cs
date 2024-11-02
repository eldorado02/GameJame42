using UnityEngine;
using System.Collections;


public class SpotlightController : MonoBehaviour
{
    public float lightDistance = 5f; // Distance of the spotlight
    public UnityEngine.Rendering.Universal.Light2D lightSource; // Reference to the Point Light 2D
    public float lightDuration = 2f; // Duration the light stays on
    public GameObject projectilePrefab; // Assign your projectile prefab in the inspector
    public float projectileSpeed = 10f; // Speed of the projectile
    public SpriteRenderer player;
    public GameObject   p;
    private bool isLightOn = false;

    private Player_Ammo ammo;

    void    Start()
    {
        ammo = player.GetComponent<Player_Ammo>();
    }

    void Update()
    {
        // Check if the right mouse button is clicked
        if (Input.GetMouseButtonDown(1) && ammo.ammo > 0)
        {
            ActivateLight();
            ammo.ammo--;
        }
    }
    
    private void FireProjectile()
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

    private void ActivateLight()
    {
        isLightOn = true;
        lightSource.enabled = true;

        if (isLightOn)
            isLightOn = false;
        // Start the coroutine to turn off the light after the duration
        StartCoroutine(Ft_fire());
        StartCoroutine(TurnOffLightAfterDuration());
    }

    private IEnumerator TurnOffLightAfterDuration()
    {
        yield return new WaitForSeconds(lightDuration);
        lightSource.enabled = false;
        isLightOn = false;
    }

    private IEnumerator Ft_fire()
    {
        while (lightSource.enabled) // Infinite loop to repeat the function
        {
            FireProjectile(); // Call your function
            yield return new WaitForSeconds(0.1f); // Wait for the specified interval
        }
    }
}
