using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellscript : MonoBehaviour

{
    public bool alive = false;
    bool preAlive;
    public bool nextAlive;
    public int x = -1;
    public int y = -1;
    // Start is called before the first frame update

    Renderer renderer;
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        preAlive = alive;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (preAlive != alive)
        {
            updateColor();
            if (this.alive)
            {
                renderer.material.color = Color.magenta;

            }
            else
            {
                renderer.material.color = Color.yellow;
            }

        }
        preAlive = alive;
    }

    public void updateColor()
    {
        if(renderer == null)
        {
            renderer = 
        }
        if(this.alive)
        {
            renderer.material.color = Color.magenta;

        }
        else {
            renderer.material.color = Color.yellow;
        }
  
    }
}
