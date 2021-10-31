using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An interface for objects in the game world that wish to be clicked on
public interface IClickHandler {
	public void HandleClickedOn();
}


// A class for managing clickin on objects in the game world
public class ClickManager : MonoBehaviour
{

    // Called once to per frame to update clicks as necessary
    public void ManageClicks()
    {
		if(Input.GetButtonDown("Fire1")){
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D mouseHit = Physics2D.Raycast(mousePos, Vector2.zero);
			mouseHit.collider?.GetComponent<IClickHandler>()?.HandleClickedOn();
		}
    }

}
