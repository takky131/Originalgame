using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCam : MonoBehaviour
{
    [SerializeField] GameObject targetObj;
    Vector3 targetPos;
    Vector3 roteuler;

    //回転の制限
    [SerializeField] float ANGLE_LIMIT_UP = 45f;
    [SerializeField] float ANGLE_LIMIT_DOWN = -45f;

    void Start()
    {
        targetPos = targetObj.transform.position;
        roteuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
    }

    void Update()
    {
        rotateCameraAngle();
    }

    //カメラの回転制御
    private void rotateCameraAngle()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position = targetObj.transform.position - Vector3.down * 1.4f - Vector3.forward * 3f;
        targetPos = targetObj.transform.position;

        // マウスの右クリックを押している間
        // if (Input.GetMouseButton(2)) {

        // マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 300f);
        // カメラの垂直移動（※角度制限なし）
        //transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 300f);

        //カメラの垂直移動(角度制限あり)
        roteuler = new Vector3(Mathf.Clamp(roteuler.x - mouseInputY * Time.deltaTime * 200f,
            ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.localEulerAngles.y, 0f);
        transform.localEulerAngles = roteuler;

        //}
    }

}
