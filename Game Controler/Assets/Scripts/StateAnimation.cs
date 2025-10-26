using UnityEngine;

public class StateAnimatorController : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StopAnimation()
    {
        if (animator != null)
        {
            animator.enabled = false;
        }
    }
}
