using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public GameObject Lamp;
    public GameObject canvas;
    float lamprotate;
    // Start is called before the first frame update
    void Start()
    {
        lamprotate = 0;
        StartGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lamprotate++;
        Lamp.transform.RotateAround(new Vector3(0, lamprotate, 0),Vector3.down,0.5f);
    }
    public void StartGame()
    {
        Animator animator = canvas.GetComponent<Animator>();
        if (animator != null)
        {
            bool isGameStarted = animator.GetBool("isGameStarted");
            animator.SetBool("isGameStarted", !isGameStarted);
        }
    }
}
