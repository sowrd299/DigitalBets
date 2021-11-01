using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldToggle : MonoBehaviour, IClickHandler
{

	[SerializeField]
	private Color highlightColor;

	private Color oldColor;


	private bool redraw;
	public bool Redraw{
		get {
			return redraw;
		}
		set {
			updateColor(value);
			redraw = value;
		}
	}


	public bool Togglable{
		get; set;
	} 


	public void HandleClickedOn(){
		if(Togglable){
			Redraw = !Redraw;
		}
	}

	private void updateColor(bool highlight){
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if(sprite != null){
			if(highlight){
				oldColor = sprite.color;
				sprite.color = highlightColor;
			}else if (Redraw) {
				sprite.color = oldColor;
			}
		}
	}


}
