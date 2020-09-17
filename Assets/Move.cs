using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;
    public GameObject enemy;
    private float distance = 25f;
    float moveSpeed = 10f;
    public GameObject MainCamera;
    private GameObject CloseCamera;

    public Camera maincamera;
    public Camera closecamera;
    private float rotateSpeed = 6.0f;
    public Move move;
    GameObject rotate;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CloseCamera = GameObject.Find("CloseCam");
        rotate = GameObject.Find("Main Camera");
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


       // Vector3 eyeDir = this.transform.forward; // プレイヤーの視線ベクトル
       // Vector3 playerPos = this.transform.position; // プレイヤーの位置
        
        //Vector3 enemyPos = enemy.transform.position; // 敵の位置
       
       
        

       // float angle = 30.0f;

      // if (Vector3.Angle((enemyPos - playerPos).normalized, eyeDir) <= angle && Vector3.Distance(enemyPos, playerPos) <= distance)
       {
          // this.transform.LookAt(enemy.transform);
                 
       }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.transform.LookAt(enemy.transform);
            Debug.Log("a");


            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(CloseCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * inputVertical + CloseCamera.transform.right * inputHorizontal;

            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }


            maincamera.enabled = false;
            closecamera.enabled = true;
            move.gameObject.transform.LookAt(other.gameObject.transform.position);


        }
        else
        {
            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(MainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * inputVertical + MainCamera.transform.right * inputHorizontal;

            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }


            rotate.GetComponent<UnityChanCam>().rotateCamera();
            closecamera.enabled = false;
            maincamera.enabled = true;

        }
        
        
    }

   

    public void lookat()
    {
        this.transform.LookAt(enemy.transform);

    }

}
