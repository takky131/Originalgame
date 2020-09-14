using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator myAnimator;
    private float delta = 0;
    public float jumpLag = 1;
    // Start is called before the first frame update
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            myAnimator.SetBool("Runf Bool", true);         
        }
        else
        {
            myAnimator.SetBool("Runf Bool", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            myAnimator.SetBool("Back Bool", true);
           
        }
        else
        {
            myAnimator.SetBool("Back Bool", false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myAnimator.SetBool("Runl Bool", true);
           
        }
        else
        {
            myAnimator.SetBool("Runl Bool", false);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myAnimator.SetBool("Runr Bool", true);
           
        }
        else
        {
            myAnimator.SetBool("Runr Bool", false);
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("JumpTrigger"))
        {
            this.myAnimator.SetBool("JumpTrigger", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f && this.jumpLag < this.delta)
        {
            this.delta = 0;
            this.myAnimator.SetBool("JumpTrigger", true);
            
        }
    }
}
