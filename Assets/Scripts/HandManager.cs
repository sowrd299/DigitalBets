using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A class for spacing cards in play
public class HandManager: MonoBehaviour
{
	
	[SerializeField]
	private GameObject cardObject;


	[SerializeField]
	Vector3 step;


	private List<GameObject> hand;
	public List<GameObject> CardObjects{
		get{ return hand; }
		private set{
			hand = value;
		}
	}


	[SerializeField]
	private int handSize = 5;


	public void Init() {
		makeHand();
	}

	// Returns the position at which the ith card should be
	private Vector3 getPosition(int i) {
		return transform.position + step * i;
	}


	// Creates the game objects for the hand
	private void makeHand() {
		hand = new List<GameObject>(handSize);
		for(int i = 0; i < handSize; i++){
			GameObject card = makeCard();
			hand.Add(card);
			card.transform.position = getPosition(i);
		}
	}


	// Returns a newly created card game object
	private GameObject makeCard() {
		GameObject card = Instantiate(cardObject);
		CardDisplay disp = card.GetComponent<CardDisplay>();
		if(disp != null) {
			disp.Init();
		}
		return card;
	}


	// Puts the given card in the given position
	public void DrawCard(GameObject cardObject, Card card) {
		CardDisplay disp = cardObject.GetComponent<CardDisplay>();
		if(disp != null) {
			disp.Card = card;
		}
	}


	// Sets if cards in the hand can be selected for redraw
	public void SetToggle(bool value) {
		foreach(GameObject card in hand) {
			HoldToggle hold = card.GetComponent<HoldToggle>();
			if(hold != null){
				hold.Togglable = value;
			}
		}
	}


	// Returns the cards held in the hand
	public List<Card> GetCardsAsCardList() {
		List<Card> cards = new List<Card>(hand.Count);
		foreach(GameObject cardObject in hand){
			Card? c = cardObject.GetComponent<CardDisplay>()?.Card;
			if(c != null){
				cards.Add((Card)c);
			}
		}
		return cards;
	}


}
