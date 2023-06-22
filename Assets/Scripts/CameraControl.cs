using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float mouseSpeed;
    private float xrot, yrot;
    public float minX, maxX;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        xrot -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed;
        yrot += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed;
        xrot = Mathf.Clamp(xrot, minX, maxX);
        transform.GetChild(0).localRotation = Quaternion.Euler(xrot, 0, 0);
        transform.localRotation = Quaternion.Euler(0, yrot, 0);
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position+new Vector3(0,0.5f,0), target.transform.position, 0.3f);
    }
}
