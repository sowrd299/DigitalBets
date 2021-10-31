using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A class for displaying a card in the game
public class CardDisplay : MonoBehaviour
{

	
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


	// Called to initialize the display; must be called before the object can be used
	public void Init() {
		if(suitNames == null){
			suitNames = new Dictionary<Suit, string>();
			suitNames.Add(Suit.CLUBS, clubsName);
			suitNames.Add(Suit.DIAMONDS, diamondsName);
			suitNames.Add(Suit.HEARTS, heartsName);
			suitNames.Add(Suit.SPADES, spadesName);
		}
	}


	// Loads and displays the appropriate sprite (based on fileNameFormat)
	// 		...for the given card
	private Sprite loadSprite(Card card) {
		string fileName = String.Format(fileNameFormat, suitNames[card.Suit], card.Rank);
		Sprite sprite = Resources.Load<Sprite>(fileName) as Sprite;
		return sprite;
	}

}
