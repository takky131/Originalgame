using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{

    public Camera maincamera;
    public Camera closecamera;
    private float rotateSpeed = 6.0f;
 
    public Move move;
    GameObject rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("a");
            maincamera.enabled = false;
            closecamera.enabled = true;
            move.gameObject.transform.LookAt(other.gameObject.transform.position);

        }
        else

        {
            rotate.GetComponent<UnityChanCam>().rotateCamera();
            closecamera.enabled = false;
            maincamera.enabled = true;
        }

    }
}
