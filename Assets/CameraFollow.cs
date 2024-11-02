using UnityEngine;
using Cinemachine;
public class CameraControl : MonoBehaviour
{
    public Transform player; // Reference to the player transform
    public float xmin = -5; // The threshold point
    public float xmax; // The threshold point
    public float ymax; // The threshold point
    private CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine Virtual Camera
    void Start()
    {
        // Get the Cinemachine Virtual Camera component
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        // Check if the player has crossed the threshold
        if (player.position.x <= xmin || player.position.x >= xmax || player.position.y > ymax) // You can modify this to check the y-axis if needed
        {
            // Stop the camera from following the player
            virtualCamera.Follow = null;
            virtualCamera.LookAt = null; // Optional: Stop looking at the player as well
        }
        else
        {
            virtualCamera.Follow = player;
        }
    }
}






