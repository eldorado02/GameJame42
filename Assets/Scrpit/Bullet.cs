using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float destroyTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the specified tag
        if (other.CompareTag("fantome"))
        {
            // Destroy the collided object
            Destroy(other.gameObject);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
