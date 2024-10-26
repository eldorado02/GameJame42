using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float speed = 2.0f; // Speed at which the enemy follows
    public float followDistance = 5.0f; // Distance within which the enemy starts following
    public float maxChaseDistance = 10.0f; // Maximum distance the enemy will chase the player

    void Update()
    {
        // Check if player is assigned
        if (player == null) return;

        // Calculate distance to player
        float distance = Vector2.Distance(transform.position, player.position);

        // If the player is within follow distance and not beyond max chase distance
        if (distance < followDistance && distance < maxChaseDistance)
        {
            // Calculate direction to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
