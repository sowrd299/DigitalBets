using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	[SerializeField]
	private GameObject cardObject;


	[SerializeField]
	private int handSize = 5;

	[SerializeField]
	private CardPositions handPositions;


	private List<GameObject> hand;
	private Deck deck;
	private MoneyManager moneyManager;
	private PayoutManager payoutManager;
	private UiManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
		deck = GetComponent<Deck>();
		deck.init();
		moneyManager = GetComponent<MoneyManager>();
		payoutManager = GetComponent<PayoutManager>();
		uiManager = GetComponent<UiManager>();
		makeHand();
		NextRound();
    }


	private void makeHand() {
		hand = new List<GameObject>(handSize);
		for(int i = 0; i < handSize; i++){
			GameObject card = makeCard();
			hand.Add(card);
			if(handPositions != null){
				card.transform.position = handPositions.GetPosition(i);
			}
		}
	}

	
	private GameObject makeCard(){
		GameObject card = Instantiate(cardObject);
		CardDisplay disp = card.GetComponent<CardDisplay>();
		if(disp != null) {
			disp.Init();
		}
		return card;
	}


	// Begins a new hand
	private void setupRound() {
		deck.shuffleAll();
		foreach(GameObject card in hand){
			drawCard(card);
			HoldToggle hold = card.GetComponent<HoldToggle>();
			if(hold != null){
				hold.Togglable = true;
			}
		}
	}


	private void drawCard(GameObject cardObject){
		CardDisplay disp = cardObject.GetComponent<CardDisplay>();
		if(disp != null) {
			disp.Card = deck.DrawCard();
		}
	}




    // Update is called once per frame
    void Update()
    {
		GetComponent<ClickManager>().ManageClicks();
    }

	// GAME LOOP METHODS

	public void ConfirmHold(){
		redrawHand();
		RoundResult result = payoutManager.GetRoundResult(getHandAsCardList());
		moneyManager.Payout(result.Payout);
		uiManager.ShowEndOfRoundUi();
		uiManager.SplashText(result.Name);
	}

	private void redrawHand(){
		foreach(GameObject card in hand){
			HoldToggle hold = card.GetComponent<HoldToggle>();
			if(hold != null){
				if(hold.Redraw){
					drawCard(card);
				}
				hold.Redraw = false;
				hold.Togglable = false;
			}
		}
	}

	private List<Card> getHandAsCardList(){
		List<Card> cards = new List<Card>(hand.Count);
		foreach(GameObject cardObject in hand){
			Card c = cardObject.GetComponent<CardDisplay>()?.Card;
			if(c != null){
				cards.Add(c);
			}
		}
		return cards;
	}

	public void NextRound(){
		uiManager.ShowBetUi();
	}


	public void PlaceBet(int amount){
		setupRound();
		moneyManager.PlaceBet(amount);
		uiManager.ShowHoldUi();
	}
	

}
