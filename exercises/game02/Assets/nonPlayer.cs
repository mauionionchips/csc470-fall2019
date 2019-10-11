using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nonPlayer : MonoBehaviour
{
    //character controller make sure we dont go in walls
    public CharacterController cc1;
    float moveSpeed1 = 8;
    float rotateSpeed1 = 70;
    //y velocity
    float yVel1 = 0;
    float gravityModifier1 = 0.05f;

    bool previousIsGroundedValue1;

    

    private Rigidbody rb1;
    



    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody>();
        
        

        previousIsGroundedValue1 = cc1.isGrounded;

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, rotateSpeed1 * Time.deltaTime * hAxis, 0);

        Vector3 amountToMove1 = transform.forward * moveSpeed1 * Time.deltaTime * vAxis;

        if (cc1.isGrounded)
        {
            if (!previousIsGroundedValue1)
            {
                yVel1 = 0;
            }

        }
        else
        {
            yVel1 = yVel1 + Physics.gravity.y * gravityModifier1 * Time.deltaTime;
        }

        amountToMove1.y = yVel1;

        cc1.Move(amountToMove1);
        Vector3 camPos = transform.position + transform.forward * -10 + Vector3.up * 3;
        Camera.main.transform.position = camPos;
        Camera.main.transform.LookAt(transform);


    }
  

    }
  