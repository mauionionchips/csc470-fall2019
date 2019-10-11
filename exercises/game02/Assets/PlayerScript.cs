using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //character controller make sure we dont go in walls
    public CharacterController cc;

    
    float moveSpeed = 8;
    float rotateSpeed = 70;
    //y velocity
    float yVel = 0;
    float gravityModifier = 0.05f;

    bool previousIsGroundedValue;

    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        

        previousIsGroundedValue = cc.isGrounded;

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
            if (!previousIsGroundedValue)
            {
                yVel = 0;
            }
            
        }
        else
        {
            yVel = yVel + Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        amountToMove.y = yVel;

        cc.Move(amountToMove);

        //change the camera position
        Vector3 camPos = transform.position + transform.forward * -10 + Vector3.up * 3;
        Camera.main.transform.position = camPos;
        Camera.main.transform.LookAt(transform);
    }
    private void OnCollisionEnter(Collision other)
    {

        CellScript Cell = other.gameObject.GetComponent<CellScript>();
        if (Cell.alive)
        {
            if (other.gameObject.CompareTag("Cell"))
            {
                other.gameObject.SetActive(false);

            }
        

            //count = count + 1;
            //SetCountText();


        }


    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win";
        }

    }
}
