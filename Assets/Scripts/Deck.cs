using System; // for Enum
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

	[SerializeField]
	private int minRank = 1;
	[SerializeField]
	private int maxRank = 13;

	private List<Card> cards;

	private int nextCard;


	// initializes the object
	public void init(){
		cards = makeCards();
	}


	// returns list of the cards for this object
	private List<Card> makeCards(){
		var suits = Enum.GetValues(typeof(Suit));
		List<Card> newCards = new List<Card>(suits.Length * maxRank-minRank);
		foreach(Suit suit in suits){
			for(int rank = minRank; rank <= maxRank; rank++){
				newCards.Add(new Card(suit, rank));
			}
		}
		return newCards;
	}


	// shuffles all cards not yet drawn from the deck
	public void shuffleRemaining(){
		for(int i = nextCard; i < cards.Count; i++){
			int r = UnityEngine.Random.Range(i, cards.Count);
			Card swap = cards[i];
			cards[i] = cards[r];
			cards[r] = swap;
		}
	}


	// re-adds all cards to the deck and shuffles them
	public void shuffleAll(){
		nextCard = 0;
		shuffleRemaining();
	}


	public Card DrawCard(){
		Card card = cards[nextCard];
		nextCard++;
		return card;
	}


}
