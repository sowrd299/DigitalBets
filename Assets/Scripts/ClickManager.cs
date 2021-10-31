using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickHandler {
	public void HandleClickedOn();
}

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
