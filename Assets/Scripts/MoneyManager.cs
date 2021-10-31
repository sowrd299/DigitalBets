using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

	[SerializeField]
	private int startingMoney;


	[SerializeField]
	private Text display;	


	private int money;
	public int Money { 
		get {
			return money;
		}
		private set {
			money = value;
			display.text = Money.ToString();
		}
	}

	public int Bet { 
		get; private set;
	}

	
	void Start(){
		Money = startingMoney;
	}


	public void PlaceBet(int bet) {
		Money -= bet;
		Bet = bet;
	}

	public void Payout(float factor){
		Money += (int)Mathf.Floor(Bet * factor);
	}

}
