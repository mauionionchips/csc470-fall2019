using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
    
{
    //character controller make sure we dont go in walls
    public CharacterController cc;
    float moveSpeed = 8;
    float rotateSpeed = 70;
    //y velocity
    float yVel = 0;

    float jumpForce = 10;
    float gravityModifier = 0.05f;


    bool prevIsGounded;
    // Start is called before the first frame update
    void Start()
    {
        prevIsGounded = cc.isGrounded;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        Vector3 amountToMove = transform.forward * moveSpeed * Time.deltaTime * vAxis;



        if (cc.isGrounded)
        {
            if (!prevIsGounded && cc.isGrounded)
            {
                yVel = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVel = jumpForce;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                yVel = 0;

            }
            yVel += Physics.gravity.y * gravityModifier;


        }
        
        
        
        //jumping means create our own gravity
        //define the y value within the vector3
        amountToMove.y = yVel;

        cc.Move(amountToMove);

        prevIsGounded = cc.isGrounded;

        //change the camera position
        Vector3 camPos = transform.position + transform.forward * -10 + Vector3.up * 3;
        Camera.main.transform.position = camPos;
        Camera.main.transform.LookAt(transform);

        Debug.Log(yVel);

    }

}
