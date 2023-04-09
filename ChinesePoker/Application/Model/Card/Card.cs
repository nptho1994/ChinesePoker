namespace pk_Application.Model.Card;

public class Card
{
    public CardSuit Suit { get; set; }
    public CardRank Rank { get; set; }
    public int IndexOfDesk { get; set; }
    public string Uuid { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Init card by name of suitName and name of rankName (1, S) => 1♠
    /// Suit: [Hearts, Diamonds, Clubs, Spades]
    /// Rank: [Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King]
    /// </summary>
    /// <param name="suitName"></param>
    /// <param name="rankName"></param>
    public Card(string rankName, string suitName)
    {
        Suit = new CardSuit(suitName);
        Rank = new CardRank(rankName);
        IndexOfDesk = Rank.Index * 4 + Suit.Index;
        Uuid = Rank.Name + Suit.ShortName;
        Name = Rank.Name + Suit.Value;
    }

    /// <summary>
    /// Init card by name of suitName and index of rank (0, S) => 1♠
    /// Suit: [Hearts, Diamonds, Clubs, Spades]
    /// Rank: [Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King]
    /// </summary>
    /// <param name="suitName"></param>
    /// <param name="rankIndex"></param>
    public Card(int rankIndex, string suitName)
    {
        Suit = new CardSuit(suitName);
        Rank = new CardRank(rankIndex);
        IndexOfDesk = Rank.Index * 4 + Suit.Index;
        Uuid = Rank.Name + Suit.ShortName;
        Name = Rank.Name + Suit.Value;
    }

    /// <summary>
    /// Init card by name of index of suit and index of rank (0, 0) => 1♠
    /// Suit: [Hearts, Diamonds, Clubs, Spades]
    /// Rank: [Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King]
    /// </summary>
    /// <param name="suitIndex"></param>
    /// <param name="rankIndex"></param>
    public Card(int rankIndex, int suitIndex)
    {
        Suit = new CardSuit(suitIndex);
        Rank = new CardRank(rankIndex);
        IndexOfDesk = Rank.Index * 4 + Suit.Index;
        Uuid = Rank.Name + Suit.ShortName;
        Name = Rank.Name + Suit.Value;
    }

    /// <summary>
    /// Init card by uuid (the input string is get by data stored) (1S) => 1♠
    /// Suit: [Hearts, Diamonds, Clubs, Spades]
    /// Rank: [Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King]
    /// </summary>
    /// <param name="uuid"></param>
    /// <exception cref="Exception"></exception>
    public Card(string uuid)
    {
        if (string.IsNullOrWhiteSpace(uuid) || uuid.Length != 2)
        {
            throw new Exception($"Can not generate card with uuid {uuid}");
        }

        var isParseRank = int.TryParse(uuid[0].ToString(), out var rank);
        if (isParseRank == false)
        {
            throw new Exception($"Can not parse rank with value {uuid[0]}");
        }

        Suit = new CardSuit(uuid[1]);
        Rank = new CardRank(rank);
        IndexOfDesk = Rank.Index * 4 + Suit.Index;
        Uuid = Rank.Name + Suit.ShortName;
        Name = Rank.Name + Suit.Value;
    }
}
