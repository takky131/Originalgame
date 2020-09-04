using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanCam : MonoBehaviour
{
    private GameObject Unitychan;
    private GameObject enemy;
    private GameObject maincamera;
    private float rotateSpeed = 4.0f;
    Renderer enemyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Unitychan = GameObject.Find("unitychan");
        enemy = GameObject.Find("Ethan");
        maincamera = Camera.main.gameObject;
        GameObject enemyObject = GameObject.Find("EthanBody");    
        enemyRenderer = enemyObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyRenderer.isVisible)
        {
            this.transform.LookAt(enemy.transform);
        }
        else
        {
            rotateCamera();
        }
        rotateCamera();
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, 0, 0);
        maincamera.transform.RotateAround(Unitychan.transform.position, Vector3.up, angle.x);
    }

}
