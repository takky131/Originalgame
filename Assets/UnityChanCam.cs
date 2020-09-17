using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanCam : MonoBehaviour
{
    public GameObject Unitychan;
    public GameObject enemy;
    public Camera maincamera;
    public Camera closecamera;
    private float rotateSpeed = 6.0f;
    public Renderer enemyRenderer;
    private float distance = 25f;
    public Move move;


    // Start is called before the first frame update
    void Start()
    {


        closecamera.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        
       // Vector3 eyeDir = this.transform.forward; // プレイヤーの視線ベクトル
        //Vector3 playerPos = this.transform.position; // プレイヤーの位置
        //Vector3 enemyPos = enemy.transform.position; // 敵の位置

        //float angle = 30.0f;

       // if (Vector3.Angle((enemyPos - playerPos).normalized, eyeDir) <= angle && Vector3.Distance(enemyPos, playerPos) <= distance)
        {
           // this.transform.LookAt(Unitychan.transform);
           // maincamera.enabled = false;
            //closecamera.enabled = true;
            //move.lookat();

        }
        //else

        {
            //rotateCamera();
            //closecamera.enabled = false;
            //maincamera.enabled = true;
        }
        
    }

   // private void OnTriggerStay(Collider other)
   // {
       // if (other.gameObject.tag == "Enemy")
      //  {
       //     Debug.Log("a");
          //  maincamera.enabled = false;
          //  closecamera.enabled = true;
            //move.gameObject.transform.LookAt(other.gameObject.transform.position);

//        }
  //      else

    //    {
      //      rotateCamera();
        //    closecamera.enabled = false;
          //  maincamera.enabled = true;
        //}

//    }

    public void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, 0, 0);
        maincamera.transform.RotateAround(Unitychan.transform.position, Vector3.up, angle.x);
    }          


}
