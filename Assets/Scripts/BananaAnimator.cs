using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaAnimator : MonoBehaviour
{
    public Animator animator;
    private bool isAnimating;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("RightArrow");
  
            //animator.SetBool("animate", true);
            //animator.SetTrigger("animate");
       
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left arrow");

            animator.Play("Spin");
            //SetTrigger("idle");
            //animator.SetBool("animate", false);


        }
    }

    //just what overlaps you...OVERLAP...90% time you use rthis
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("BANANA OnTriggerEnter");
        //animator.SetTrigger("idle");
       //animator.SetBool("animate", true);

    }

    //two events collider...physics collisions
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("BANANA OnCollisionEnter: "  +col.contacts + " how hard: " + col.relativeVelocity);
        animator.SetTrigger("animate");
        //animator.SetBool("isAnimating", false);
    }


}
