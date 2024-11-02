using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float destroyTime = 5f;
    private Animator anim;

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
            Debug.Log("eto");
            anim = other.GetComponent<Animator>();
            anim.SetBool("Died", true);
            StartCoroutine(CallFunctionOnceAfterDelay(.7f, other.gameObject));
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private IEnumerator CallFunctionOnceAfterDelay(float delay, GameObject other)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);
        
        // Call your function here
        DestroyOther(other);
    }

    private void DestroyOther(GameObject other)
    {
        Destroy(other);
    }

}
