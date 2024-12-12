using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    GameObject canvas;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        canvas = GameObject.Find("UI Canvas");
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
            animator.SetTrigger("Next");

        if (Input.GetKeyDown("left"))
            animator.SetTrigger("Back");

        if (Input.GetKeyDown("space"))
            canvas.SetActive(!canvas.activeInHierarchy);


    }
}
