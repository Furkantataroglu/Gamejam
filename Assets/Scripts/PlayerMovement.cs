using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody RD;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    
    // Start is called before the first frame update
    void Start()
    {
        //RD = GetComponent<Rigidbody>();
        controller= GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {                                    //x ekseni //                      //RD.velocity.y yaptığımız için y ekseni hiç değişmeyecek
       /* RD.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, RD.velocity.y, Input.GetAxis("Vertical") * moveSpeed  );

        if(Input.GetButtonDown("Jump"))
        {
            RD.velocity = new Vector3(RD.velocity.x, jumpForce, RD.velocity.z);
            
        }
        */
         //karakter havada yön değiştiremesin diye bunu isgroundedin içine koyabiliriz. 
           // moveDirection = new Vector3 (Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y,Input.GetAxis("Vertical") * moveSpeed );
        float yStore = moveDirection.y;
         moveDirection= (transform.forward * Input.GetAxis("Vertical"))+ (transform.right * Input.GetAxis("Horizontal")); 
         moveDirection = moveDirection.normalized* moveSpeed;
         moveDirection.y=yStore;
        if(controller.isGrounded)
        {  
            moveDirection.y = 0f;
        if(Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
            
        }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y  * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
   
    
}
