using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision colli)
 {
            if (colli.gameObject.tag == "Player")
           {
                    Destroy (gameObject);
                   
           }
 }
}
