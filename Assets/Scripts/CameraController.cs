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
    public float maxViewAngel;
    public float minViewAngel;
    void Start()
    {
        if(!useOffsetValues)
        {
            offset=target.position - transform.position;
        }
       pivot.transform.position = target.transform.position;
       //pivot.transform.parent = target.transform;

       pivot.transform.parent = null;
        //mouse gizleme
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {  
        pivot.transform.position = target.transform.position;
        
         //get the x position of the mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0,horizontal,0);
        //get the Y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y")* rotateSpeed;
        //pivot.Rotate(-vertical,0,0);

        //camera rotation limit/up down
        if(pivot.rotation.eulerAngles.x >maxViewAngel && pivot.rotation.eulerAngles.x <180f)
        {
            pivot.rotation = Quaternion.Euler(45f,0,0);
        }
        if(pivot.rotation.eulerAngles.x >180f && pivot.rotation.eulerAngles.x < 360f + minViewAngel)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngel,0,0);
        }
        //move the camera based on the current rotation of the target and original offset
        float desiredYAngle = pivot.eulerAngles.y;
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
