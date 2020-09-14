using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanCam : MonoBehaviour
{
    public GameObject Unitychan;
    public GameObject enemy;
    public GameObject maincamera;
    public GameObject closecamera;
    private float rotateSpeed = 6.0f;
    public Renderer enemyRenderer;
    private float distance = 25f;
  

    // Start is called before the first frame update
    void Start()
    {
       
        maincamera = Camera.main.gameObject;      
        closecamera.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 eyeDir = this.transform.forward; // プレイヤーの視線ベクトル
        Vector3 playerPos = this.transform.position; // プレイヤーの位置
        Vector3 enemyPos = enemy.transform.position; // 敵の位置

        float angle = 30.0f;

        if (Vector3.Angle((enemyPos - playerPos).normalized, eyeDir) <= angle && Vector3.Distance(enemyPos, playerPos) <= distance)
        {
            this.transform.LookAt(Unitychan.transform);
            maincamera.SetActive(false);
            closecamera.SetActive(true);
        }
        else
        {
            rotateCamera();
            closecamera.SetActive(false);
            maincamera.SetActive(true);
        }
        
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, 0, 0);
        maincamera.transform.RotateAround(Unitychan.transform.position, Vector3.up, angle.x);
    }          


}
