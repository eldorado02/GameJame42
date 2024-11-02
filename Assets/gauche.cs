using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;          // Speed of the platform
    public float moveDistance = 3f;   // Distance the platform will move from its starting point
    private Vector2 startPosition;    // Starting position of the platform
    private bool movingRight = true;  // Direction of movement

    void Start()
    {
        // Save the starting position of the platform
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position of the platform
        float move = speed * Time.deltaTime;
        if (movingRight)
        {
            transform.Translate(move, 0, 0);

            // Check if the platform has moved beyond the right limit
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false; // Reverse the direction
            }
        }
        else
        {
            transform.Translate(-move, 0, 0);

            // Check if the platform has moved beyond the left limit
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Reverse the direction
            }
        }
    }
}

