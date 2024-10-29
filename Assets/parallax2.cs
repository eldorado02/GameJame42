using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{
    public Transform camera;  // La caméra pour suivre le mouvement
    public float parallaxFactor; // Facteur de parallax

    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = camera.position;
    }

    void Update()
    {
        Vector3 deltaMovement = camera.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, 0, 0);
        lastCameraPosition = camera.position;
    }
}
