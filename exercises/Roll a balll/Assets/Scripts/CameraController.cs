using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //two variables: a public GameObject reference to the player and a private(set the value in the script) vector3 to hold offset value.
    public GameObject player;
    //offset value = current camera pistion value - player position value
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

        
    }

    // Update is called once per frame

    //LateUpdate is guaranteed to run after all items have been processed in Update.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        
    }
}
