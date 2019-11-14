using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// This will hold a reference to whichever Unit was selected last.
	UnitScript selectedUnit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// This is how you detect that the left mouse button has been clicked.
        if (Input.GetMouseButtonDown(0)) {
			// Create a ray from the mouse position (in camera/ui space) to 3d world space.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// After the Raycast, 'hit' will store information about what the raycast hit.
			RaycastHit hit;
			// The line below actually performs the "raycast". This will 'shoot' a line from the
			// mouse position into the world, and it if hits something marked with the layer 'ground', 
			// return true.
			if (Physics.Raycast(ray, out hit, 9999)) {
				// Check to see if the thing the raycast hit was marked with the layer 'ground'.
				if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ground")) {
					// If so, set the destination of the selectedUnit to the point on the ground
					// that the raycast hit.
					if (selectedUnit != null) {
						selectedUnit.destination = hit.point;
					}
				}
			} else {
				// If we got here, it means that the raycast didn't hit anything, so let's deselect.
				if (selectedUnit != null) {
					selectedUnit.selected = false;
					selectedUnit.setColorOnMouseState();
					selectedUnit = null;
				}
			}
		}
	}

	public void selectUnit(UnitScript unit)
	{
		// If we have selected something previously, unselect it and update the color.
		if (selectedUnit != null) {
			selectedUnit.selected = false;
			selectedUnit.setColorOnMouseState();
		}

		// Select the unit that was passed in, and update its color.
		selectedUnit = unit;
		selectedUnit.selected = true;
		selectedUnit.setColorOnMouseState();
	}
}
