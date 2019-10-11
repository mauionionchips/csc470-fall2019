using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//in the public class section: where variables are
public class PlayerController : MonoBehaviour
{
    
    public float speed;
    //create Text variable called countText to hold a reference to the UI text component on our UI text gameobject.    public Text countText;
    public Text countText;
    public Text winText;

    
    

    private Rigidbody rb;
    private int count;
    // Start is called before the first frame update
    //reference made are going to be here(link rb with script)
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        

    }

    // Update is called once per frame
    void Update()
    {
        
        }

        //FixedUpdate is called just before any physics calculations.
        //we will moving farward by applying physics to our rigidbody.
        void FixedUpdate()
        {
            //Input(ctrl+':doesnt work):use this class to read the axes set up in the input Manager, and to access multi-touch/accelerometer data on mobile devices.
            //GetAxis grabs the input from player through the keyboard.
            //moveHorizontal & moveVertical record the input from the horizontal and vertical axis which are controled by the keys on the keyboard.
            //we will use this input to add forced to rigidbody and move the player gameobject in the scene(any physics). 

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);


        }
        //Physics engine doesnt allow two colliders volumes to overlap. When the physics engine detects that two or more colliders were overlaped that fram, the physics object would look the object and analyse the speed,rotation and shape, and calculate a collision. One of the major facts in the calculation is whether the colliders are static or dynamic. Static colliders are usually non-moving parts of your scene, like the walls, the floors. Dynamic colliders are things that move, like the player's sphere or car. When calculating a collision, the setic geometry will not be affected by the collision, but the dynamic object will be. In our case, the player's sphere is dynamic while moving geometry. It is bouncing off the static geometry of the cubes, just as it bounces off the static geometry of the walls.
        //...The physics engine can however allow the penetration or overlap of collider volumes. When it does this, the physics engine still calculates the collider volumes who keeps track of the collider overlap, But it deosnt physically add on the overlapping objects. It doesnt cause collision. 
        //...We do this by making our colliders triggers or trigger colliders. When we make our colliders into a trigger or trigger collider, we can detact the context of that trigger through the OntriggerEvent messagers. 
        //...When a collider is a trigger, you can do clever things like place a trigger in the middle of doorway inside a ... game. And when the player enters the trigger, the minimap updates and the message displays you have discovered this room.
        //...We are using OnTriggerEnter in our code rather than OnCollisionEnter, so we need to change our collider volumes into trigger volumes.
        //...Look at the prehab asset and the box collider component, tick the "Is Trigger"
        //Unity expects us to move colliders with simply indicating unity which colliders are dynamic before we move them. 
        //...We use this by using the rigidbody component. Any gameobject with a collider and a rigidbody is considered dynamic. Without rigidbody, static.
        // So, static collider(deosnt move) shouldn't move(like walls and floors), dynamic colliders can move(have rigidbody attached). Standard rigidbody are moved using physic forces. Kinematic rigidbody are moved using their transform. 
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pick Up"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();


            }


        }
        //In Unity, we can associate a reference to our count text by draging count text to game object into the slot. 
        void SetCountText()
        {
            countText.text = "Count:" + count.ToString();
            if (count >= 12)
            {
                winText.text = "You Win";
            }

        }
}


