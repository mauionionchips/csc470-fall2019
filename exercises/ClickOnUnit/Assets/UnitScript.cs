using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public bool selected = false;
    public bool hover;
    Color defaultColor;
    Color hoverColor;
    public Color slectedColor;

    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
       renderer = gameObject.GetComponent<Renderer>();
        defaultColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        hover = true;
        setColorOnMouseState();
        
    }
    private void OnMouseExit()
    {
        setColorOnMouseState();
    }
    private void OnMouseDown()
    {
        selected = !selected;
        setColorOnMouseState();
    }
    void setColorOnMouseState()
    {
        if(selected)
        {
            Color selectedColor = default;
            renderer.material.color = selectedColor;
        }
    }
}
