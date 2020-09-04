using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanCnt : MonoBehaviour
{
    
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {

        this.myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            myAnimator.SetBool("Runf Bool", true);
        }
        else
        {
            myAnimator.SetBool("Runf Bool", false);
            Debug.Log(myAnimator.GetBool("Runf Bool"));
        }  

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myAnimator.SetBool("Back Bool", true);
        }
        else
        {
            myAnimator.SetBool("Back Bool", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myAnimator.SetBool("Runl Bool", true);
        }
        else
        {
            myAnimator.SetBool("Runl Bool", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myAnimator.SetBool("Runr Bool", true);
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
