using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

	[SerializeField]
	private int minRank = 1;
	[SerializeField]
	private int maxRank = 13;

	private HashSet<Card> drawnCards;


	// initializes the object
	public void Init(){
	}


	// shuffles all cards not yet drawn from the deck
	public void shuffleRemaining() { }


	// re-adds all cards to the deck and shuffles them
	public void shuffleAll() {
		drawnCards = new HashSet<Card>();
	}


	// Pops a card off the deck
	public Card DrawCard(){
		Card card;
		do {
			Suit suit = (Suit) Random.Range(0, 4);
			int rank = Random.Range(minRank, maxRank+1);
			card = new Card(suit, rank);
		} while(drawnCards.Contains(card));
		drawnCards.Add(card);
		return card;
	}


}
