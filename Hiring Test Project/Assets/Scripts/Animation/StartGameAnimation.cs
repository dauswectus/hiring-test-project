using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameAnimation : MonoBehaviour
{
    public void StartGame()
    {
        Animator animator = GetComponent<Animator>();
        if(animator != null)
        {
            bool isGameStarted = animator.GetBool("isGameStarted");
            animator.SetBool("isGameStarted", !isGameStarted);
        }
    }
}
