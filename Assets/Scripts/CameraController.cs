using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    public Transform pivot;
    void Start()
    {
        if(!useOffsetValues)
        {
            offset=target.position - transform.position;
        }
       pivot.transform.position = target.transform.position;
       pivot.transform.parent = target.transform;
        //mouse gizleme
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {   //get the x position of the mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0,horizontal,0);
        //get the Y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y")* rotateSpeed;
        pivot.Rotate(-vertical,0,0);
        //move the camera based on the current rotation of the target and original offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle,0);
        transform.position=target.position-(rotation*offset);


        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x , target.position.y -0.5f,transform.position.z);
        }
        
        //transform.position = target.position  - offset;
        transform.LookAt(target.transform);

        
    }
}
