
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlaneScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    float rotateSpeed = 90;
    public Text scoreText;
    public Text winAlert;
    public Text countDownAlert;
    private int score;
    float countDown = 10;
    public float chargeRate = 5;
    float charge = 0;
    int randScoreAdder;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        winAlert.text = "";
        countDownAlert.text = "";
        SetScoreText();
        randScoreAdder = Random.Range(2, 5);

        Vector3 camPos = transform.position - transform.forward * 8 + Vector3.up * 5;
        Camera.main.transform.position = camPos;
        Camera.main.transform.LookAt(transform.position + transform.forward * 5);




    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Rotate(0, rotateSpeed * Time.deltaTime * moveHorizontal, 0);
        transform.position += transform.forward * speed * Time.deltaTime * moveVertical;

        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            countDownAlert.text = "Almost There!";

        }

        if (Input.GetKey(KeyCode.Space))
        {
            charge += chargeRate * Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.position * charge);

        }

    }
    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= (9 + randScoreAdder))
        {
            winAlert.text = "You've gotten this!";
        }
    }


}


