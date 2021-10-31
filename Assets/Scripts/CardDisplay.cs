using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{

	[SerializeField]
	private string fileNameFormat = "Sprites/Cards/img_card_{0}{1:D2}"; // I don't like magic numbers... but thats how format works :(

	[SerializeField]
	private string clubsName = "c";
	[SerializeField]
	private string diamondsName = "d";
	[SerializeField]
	private string heartsName = "h";
	[SerializeField]
	private string spadesName = "s";


	private Dictionary<Suit, string> suitNames;

	public void Init(){
		suitNames = new Dictionary<Suit, string>();
		suitNames.Add(Suit.CLUBS, clubsName);
		suitNames.Add(Suit.DIAMONDS, diamondsName);
		suitNames.Add(Suit.HEARTS, heartsName);
		suitNames.Add(Suit.SPADES, spadesName);
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

	private Sprite loadSprite(Card card){
		string fileName = String.Format(fileNameFormat, suitNames[card.Suit], card.Rank);
		Sprite sprite = Resources.Load<Sprite>(fileName) as Sprite;
		return sprite;
	}

}
