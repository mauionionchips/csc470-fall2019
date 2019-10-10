using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime provides the time between the current and previous frame. Use Time.deltaTime to move a GameObject in the y direction, at n units per second. Multiply n by Time.deltaTime and add to the y component.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        
    }
    //Prefeb is an asset that contains templet or blueprint of a gameobject or gameobject family.We create a prefeb from an existing gameobject or gameobject family, and once created, we can use this prefab in any scene in our current project. With the prefab of our pick up object, we will be able to make changes to a single instance to our scene or to a prefab asset itself. And all of the pick up objects in our game will be updated with those changes.
    //when we drag an item from our hierachy into our project view, we create a new prefab asset containing a templete or a blueprint of our gameobject or gameobject family.

}
