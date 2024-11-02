using UnityEngine;

public class SpotlightFlipper : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Assign the Sprite Renderer in the inspector
    public Transform spotlight; // Assign the spotlight GameObject in the inspector

    void Update()
    {
        // Ensure spriteRenderer and spotlight are assigned
        if (spriteRenderer != null && spotlight != null)
        {
            // Check if the sprite is flipped
            if (spriteRenderer.flipX)
            {
                // Rotate the spotlight 180 degrees around the Z-axis
                spotlight.rotation = Quaternion.Euler(0, 0, 180 + 90f);
                transform.position = new Vector2(spriteRenderer.transform.position.x + .45f, spriteRenderer.transform.position.y - 0.17f);
            }
            else
            {
                // Reset the spotlight rotation to normal
                spotlight.rotation = Quaternion.Euler(0, 0, 0 + 90f);
                transform.position = new Vector2(spriteRenderer.transform.position.x - .45f, spriteRenderer.transform.position.y - 0.17f);
            }
        }
    }
}
