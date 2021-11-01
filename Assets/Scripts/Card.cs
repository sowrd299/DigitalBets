public enum Suit {
	SPADES, HEARTS, DIAMONDS, CLUBS
}


// A struct to present a standard playing card
public struct Card {

	public Suit Suit {
		get; private set;
	}

	public int Rank {
		get; private set;
	}

	public Card(Suit suit, int rank) {
		Suit = suit;
		Rank = rank;
	}

	public static bool operator== (Card card1, Card card2){
		return card1.Suit == card2.Suit && card1.Rank == card2.Rank;
	}

	public static bool operator!= (Card card1, Card card2){
		return !(card1==card2);
	}

	public override bool Equals(object obj)
	{
		return (this as Card?) == (obj as Card?);
	}

	public override int GetHashCode()
	{
		return (Suit, Rank).GetHashCode();
	}

}
