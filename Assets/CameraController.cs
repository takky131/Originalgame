using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject lockOnTargetDetector;

    public GameObject unityChan;
    public GameObject mainCamera;
    public float rotate_speed;
    private const float ANGLE_LIMIT_UP = 60f;
    private const float ANGLE_LIMIT_DOWN = -60f;
  
    void Start()
    {

        mainCamera = Camera.main.gameObject;
        unityChan = GameObject.FindGameObjectWithTag("Unitychan");       
        lockOnTargetDetector = unityChan.GetComponentInChildren<LockOnTargetDetector>();
    }

    void Update()
    {
        transform.position = unityChan.transform.position;
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject target = lockOnTargetDetector.getTarget();

            if (target != null)
            {
                lockOnTarget = target;
            }
            else
            {
                lockOnTarget = null;
            }
        }

        if (lockOnTarget)
        {
            lockOnTargetObject(lockOnTarget);
        }
        else
        {

            rotateCmaeraAngle();
        }
            float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
    private void lockOnTargetObject(GameObject target)
    {
        transform.LookAt(target.transform, Vector3.up);
    }

        private void rotateCmaeraAngle()
    {
        Vector3 angle = new Vector3(
            Input.GetAxis("Mouse X") * rotate_speed,
            Input.GetAxis("Mouse Y") * rotate_speed,
            0
        );

        transform.eulerAngles += new Vector3(angle.y, angle.x);
    }
}