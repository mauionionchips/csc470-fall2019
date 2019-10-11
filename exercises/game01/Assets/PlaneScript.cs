
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class planeScript : MonoBehaviour
{
    
    float moveSpeed = 8;
    float rotateSpeed = 70;

    private Rigidbody rb;
    private int count;

    public Text countText;
    public Text winText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";


    }
    void Update()
    {
        //Vector3 camPos = transform.position + transform.forward * -10 + Vector3.up * 3;
        //Camera.main.transform.position = camPos;
        //Camera.main.transform.LookAt(transform);

        Vector3 camPos = transform.position + -transform.forward * 10 + Vector3.up * 8;
        Camera.main.transform.position = camPos;
        Camera.main.transform.LookAt(transform);
    }

    void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        Vector3 movement = new Vector3(hAxis, 0.0f, vAxis); ;
        rb.AddForce(movement * moveSpeed);

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //set"PickUp"tag in unity too
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();


        }


    }
    public void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Are The Winner!";
        }

    }


}


