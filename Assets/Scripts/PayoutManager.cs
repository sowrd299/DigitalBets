using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoundResult {
	public string Name {
		get; private set;
	}

	public float Payout{
		get; private set;
	}

	public RoundResult(string name, float payout){
		Name = name;
		Payout = payout;
	}

}


public class PayoutManager : MonoBehaviour
{
	[SerializeField]
	private string RoyalFlushName = "Royal Flush!!!";

	[SerializeField]
	private string StraightFlushName = "Straight Flush!!";

	[SerializeField]
	private string FourKindName = "Four of a Kind!";

	[SerializeField]
	private string FullHouseName = "Full House";

	[SerializeField]
	private string FlushName = "Flush";

	[SerializeField]
	private string StraightName = "Straight";

	[SerializeField]
	private string ThreeKindName = "Three of a Kind";

	[SerializeField]
	private string TwoPairName = "Two Pair";

	[SerializeField]
	private string JacksName = "Pair of Jacks or Better";

	[SerializeField]
	private string LossName = "You Lose";
	

	[SerializeField]
	private float RoyalFlushPayout = 800;

	[SerializeField]
	private float StraightFlushPayout = 50;

	[SerializeField]
	private float FourKindPayout = 25;

	[SerializeField]
	private float FullHousePayout = 9;

	[SerializeField]
	private float FlushPayout = 9;

	[SerializeField]
	private float StraightPayout = 4;

	[SerializeField]
	private float ThreeKindPayout = 3;

	[SerializeField]
	private float TwoPairPayout = 2;

	[SerializeField]
	private float JacksPayout = 1;
	


	public RoundResult GetRoundResult (List<Card> hand) {

		int[] rankCounts = countRanks(hand);
		int[] setsOfSize = countSetsOfSize(rankCounts);
		int maxFlush = countMaxFlush(hand);
		int maxStraight = countMaxStraight(rankCounts);

		if(maxFlush >= 5 && maxStraight >= 5){
			if(rankCounts[0] > 0 && rankCounts[9] > 0){
				return new RoundResult(RoyalFlushName, RoyalFlushPayout);
			}
			return new RoundResult(StraightFlushName, StraightFlushPayout);
		}else if(setsOfSize[4] > 0) {
			return new RoundResult(FourKindName, FourKindPayout);
		}else if(setsOfSize[3] > 0 && setsOfSize[2] > 0){
			return new RoundResult(FullHouseName, FullHousePayout); 
		}else if(maxFlush >= 5){
			return new RoundResult(FlushName, FlushPayout);
		}else if(maxStraight >= 5){
			return new RoundResult(StraightName, StraightPayout);
		}else if(setsOfSize[3] > 0){
			return new RoundResult(ThreeKindName, ThreeKindPayout);
		}else if(setsOfSize[2] > 2){
			return new RoundResult(TwoPairName, TwoPairPayout);
		}else if(setsOfSize[2] > 0){
			for(int i = 10; i < rankCounts.Length; i++){
				if(rankCounts[i] > 1){
					return new RoundResult(JacksName, JacksPayout);
				}
			}
		}
		
		return new RoundResult(LossName, 0);

	}

	private static int[] countRanks(List<Card> hand){
		int[] rankCounts = new int[13]; // TODO: Because ranks are odd, I don't necessarily like hard coding this
		foreach(Card card in hand){
			rankCounts[card.Rank-1]++;
		}
		return rankCounts;
	}

	private static int[] countSetsOfSize(List<Card> hand){
		return countSetsOfSize(countRanks(hand));
	}

	private static int[] countSetsOfSize(int[] rankCounts){
		int[] setsOfSize = new int[6];
		foreach(int count in rankCounts){
			setsOfSize[count]++;
		}
		return setsOfSize;
	}

	private static int countMaxFlush(List<Card> hand){
		int[] flushes = new int[Enum.GetValues(typeof(Suit)).Length];
		int maxFlush = 0;

		foreach(Card card in hand){
			flushes[(int)card.Suit]++;
		}

		foreach(int flush in flushes){
			if(flush > maxFlush){
				maxFlush = flush;
			}
		}

		return maxFlush;
	}

	private static int countMaxStraight(List<Card> hand){
		return countMaxStraight(countRanks(hand));
	}

	private static int countMaxStraight(int[] rankCounts){
		int maxStraight = 0;
		for(int i = 0; i < rankCounts.Length; i++){
			int straight = 0;
			int j = i;
			while(rankCounts[j] > 0){
				j = (j+1) % rankCounts.Length;
				straight++;
			}
			if(straight > maxStraight){
				maxStraight = straight;
			}
			if(j > i){
				i = j;
			}
		}
		return maxStraight;
	}

}
