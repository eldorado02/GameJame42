using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Example: Set a boolean parameter
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("iddle", true);
        }
        else
        {
            animator.SetBool("iddle", false);
        }
    }
}
