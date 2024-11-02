using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraClamp : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    private void LateUpdate()
    {
        if (virtualCamera != null)
        {
            // Get the camera's position
            var cameraPosition = virtualCamera.transform.position;
            // Clamp the position
            cameraPosition.x = Mathf.Clamp(cameraPosition.x, minBounds.x, maxBounds.x);
            cameraPosition.y = Mathf.Clamp(cameraPosition.y, minBounds.y, maxBounds.y);
            // Apply the clamped position back to the camera
            virtualCamera.transform.position = cameraPosition;
        }
    }
}