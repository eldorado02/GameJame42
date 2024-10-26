using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float speed = 2.0f; // Speed at which the enemy follows
    public float followDistance = 5.0f; // Distance within which the enemy starts following
    public float maxChaseDistance = 10.0f; // Maximum distance the enemy will chase the player

    private Animator animator;
    private bool    is_flipped = false;
    private  SpriteRenderer  s_player;

    public float rayLength = .01f; // Length of the ray

    private void Start()
    {
        animator = GetComponent<Animator>();
        s_player = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if player is assigned
        if (player == null) return;

        // Calculate distance to player
        float distance = Vector2.Distance(transform.position, player.position);

        if (transform.position.x > player.position.x)
            s_player.flipX = true;            
        else
            s_player.flipX = false;
        // If the player is within follow distance and not beyond max chase distance
        if (distance < followDistance && distance < maxChaseDistance)
        {
            // Calculate direction to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetFloat("TargetAcquired", 1);
            CastRay(direction);
        }
        else
        {
            animator.SetFloat("TargetAcquired", 0);
        }
    }

    void CastRay(Vector2 direction)
    {
        // Get the position of the SpriteRenderer
        Vector2 origin = s_player.transform.position;

        // Cast the ray
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayLength);

        // Check if the ray hit something
        if (hit.collider != null)
        {
            // Check if the hit object has the specified tag
            if (hit.collider.CompareTag("Player"))
            {
                gameOver();
            }
        }
    }

    void    gameOver()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
