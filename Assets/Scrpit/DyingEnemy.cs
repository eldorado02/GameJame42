using UnityEngine;

public class DyingEnemy : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Example: Play the "Run" animation when the player moves
        if (Input.GetKey(KeyCode.W)) // Replace with your movement input
        {
            // Set the "Run" trigger to play the run animation
            animator.SetBool("Died", true);
        }
    }
}
