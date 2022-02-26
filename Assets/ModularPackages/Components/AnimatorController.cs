using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    public void PlayAnimation(string _name)
    {
        animator.Play(_name);
    }
}
