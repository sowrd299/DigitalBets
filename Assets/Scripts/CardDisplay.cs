using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{

	private static Dictionary<string, Sprite> cachedSprites = new Dictionary<string, Sprite>();

	
	[SerializeField]
	private string fileNameFormat = "Sprites/Cards/img_card_{0}{1:D2}"; // I don't like magic numbers... but thats how format works :(

	private string clubsName = "c";
	private string diamondsName = "d";
	private string heartsName = "h";
	private string spadesName = "s";


	private static Dictionary<Suit, string> _suitNames;
	protected virtual Dictionary<Suit, string> suitNames {
		get{
			return _suitNames;
		}
		private set{
			_suitNames = value;
		}
	}


	// Called to initialize the display; must be called before the object can be used
	public void Init(){
		if(suitNames == null){
			suitNames = new Dictionary<Suit, string>();
			suitNames.Add(Suit.CLUBS, clubsName);
			suitNames.Add(Suit.DIAMONDS, diamondsName);
			suitNames.Add(Suit.HEARTS, heartsName);
			suitNames.Add(Suit.SPADES, spadesName);
		}
	}


	private Card card;
	public Card Card {
		get{
			return card;
		}
		set{
			if(card != value){
				card = value;
				GetComponent<SpriteRenderer>().sprite = loadSprite(value);
			}
		}
	}


	// Loads and displays the appropriate sprite (based on fileNameFormat)
	// 		...for the given card
	private Sprite loadSprite(Card card){
		string fileName = String.Format(fileNameFormat, suitNames[card.Suit], card.Rank);
		Sprite sprite;
		if(cachedSprites.ContainsKey(fileName)){
			sprite = cachedSprites[fileName];
		}else{
			sprite = Resources.Load<Sprite>(fileName) as Sprite;
			cachedSprites[fileName] = sprite;
		}
		return sprite;
	}

}
