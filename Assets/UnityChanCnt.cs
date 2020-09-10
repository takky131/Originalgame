using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanCnt : MonoBehaviour
{
    //private float forwardForce = 8.0f;
    private Rigidbody myRigidbody;
    private Animator myAnimator;
    public float upForce = 500.0f;
    private float delta = 0;
    public float jumpLag = 1;
    Camera cam;
    private GameObject enemy;
    private float distance = 25f;
    public float angle = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        this.myAnimator = GetComponent<Animator>();
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        Vector3 eyeDir = this.transform.forward; // プレイヤーの視線ベクトル
        Vector3 playerPos = this.transform.position; // プレイヤーの位置
        Vector3 enemyPos = enemy.transform.position; // 敵の位置

        if (Vector3.Angle((enemyPos - playerPos).normalized, eyeDir) <= angle && Vector3.Distance(enemyPos, playerPos) <= distance)
        {
            if (Input.GetKey(KeyCode.UpArrow))
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
                this.myRigidbody.velocity = new Vector3(-8, 0, 0);
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

            if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("JumpTrigger"))
            {
                this.myAnimator.SetBool("JumpTrigger", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f && this.jumpLag < this.delta)
            {
                this.delta = 0;
                this.myAnimator.SetBool("JumpTrigger", true);
                this.myRigidbody.AddForce(this.transform.up * this.upForce);
            }
        }
       
        
    }
}
