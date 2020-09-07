using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanCnt : MonoBehaviour
{
    //private float forwardForce = 8.0f;
    private Rigidbody myRigidbody;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {

        this.myAnimator = GetComponent<Animator>();
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            myAnimator.SetBool("Runf Bool", true);
            //  this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
            this.myRigidbody.velocity = new Vector3(0, 0, 10);
        }
        else
        {
            myAnimator.SetBool("Runf Bool", false);        
        }  

        if (Input.GetKey(KeyCode.DownArrow))
        {
            myAnimator.SetBool("Back Bool", true);
            this.myRigidbody.velocity = new Vector3(0, 0, -7);
        }
        else
        {
            myAnimator.SetBool("Back Bool", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myAnimator.SetBool("Runl Bool", true);
            this.myRigidbody.velocity = new Vector3(-8, 0,0);
        }
        else
        {
            myAnimator.SetBool("Runl Bool", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            myAnimator.SetBool("Runr Bool", true);
            this.myRigidbody.velocity = new Vector3(8, 0, 0);
        }
        else
        {
            myAnimator.SetBool("Runr Bool", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetTrigger("JumpTrigger");
        }      

    }
}
