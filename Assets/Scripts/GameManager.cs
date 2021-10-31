using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



	[SerializeField]
	private HandManager hand;

	[SerializeField]
	private Deck deck;

	[SerializeField]
	private MoneyManager moneyManager;

	[SerializeField]
	private PayoutManager payoutManager;

	[SerializeField]
	private UiManager uiManager;


    // Start is called before the first frame update
    void Start() {
		hand.Init();
		deck.Init();
		StartRound();
    }

    void Update()
    {
		GetComponent<ClickManager>().ManageClicks();
    }

	// GAME LOOP METHODS
	// The bellow methods are called to advance the game loop


	// FINALIZES HOLDING CARDS FOR THIS ROUND
	public void ConfirmHold(){
		redrawHand();
		RoundResult result = payoutManager.GetRoundResult(hand.GetCardsAsCardList());
		moneyManager.Payout(result.Payout);
		uiManager.ShowEndOfRoundUi();
		uiManager.SplashText(result.Name);
	}


	// Redraws cards toggled to be redrawn
	public void redrawHand() {
		foreach(GameObject cardObject in hand.CardObjects){
			HoldToggle hold = cardObject.GetComponent<HoldToggle>();
			if(hold != null){
				if(hold.Redraw){
					hand.DrawCard(cardObject, deck.DrawCard());
				}
				hold.Redraw = false;
			}
		}
		hand.SetToggle(false);
	}


	// BEGINS A NEW ROUND
	public void StartRound(){
		uiManager.ShowBetUi();
	}


	// FINALIZES BETS FOR THE CURRENT ROUND
	public void PlaceBet(int amount) {
		setupRound();
		moneyManager.PlaceBet(amount);
		uiManager.ShowHoldUi();
	}


	// Sets up cards for a new round
	private void setupRound() {
		deck.shuffleAll();
		foreach(GameObject cardObject in hand.CardObjects){
			hand.DrawCard(cardObject, deck.DrawCard());
		}
		hand.SetToggle(true);
	}
	

}
