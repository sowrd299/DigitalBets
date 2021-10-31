public enum Suit {
	SPADES, HEARTS, DIAMONDS, CLUBS
}

public class Card 
{
	public Suit Suit {
		get; private set;
	}

	public int Rank {
		get; private set;
	}

	public Card(Suit suit, int rank){
		Suit = suit;
		Rank = rank;
	}

}
