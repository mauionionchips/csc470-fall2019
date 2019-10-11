using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    

    // Update is called once per frame
    //use update instead of fixedupdate when dont need forces
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        
    }
}
