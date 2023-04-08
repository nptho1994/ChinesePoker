using static pk_Application.Common.Constant;
using static pk_Application.Common.Constant.Config;

namespace pk_Application.Model;

public class CardOnHand
{
    public List<Card> Cards { get; set; } = new List<Card>();
    public string Uuid { get; set; } = string.Empty;
    public string BestResult { get; set; } = string.Empty;
    public TypeSuitCard Spades { get; set; }
    public TypeSuitCard Clubs{ get; set; }
    public TypeSuitCard Diamonds { get; set; }
    public TypeSuitCard Hearts { get; set; }
    public RankCard RankCards { get; set; }
    public OneCard OneCard { get; set; }
    public DoubleCard DoubleCard { get; set; }
    public TripleCard TripleCard { get; set; }
    public QuadrupleCard QuadrupleCard { get; set; }


    /// <summary>
    /// Gemerate card on hand with string input 
    /// Example: JHKD8H1S2C2H5D5H7H1D9C9H4D3H
    /// </summary>
    /// <param name="handCard"></param>
    /// <exception cref="Exception"></exception>
    public CardOnHand(string handCard)
    {
        if (string.IsNullOrWhiteSpace(handCard) || handCard.Length != 26)
        {
            throw new Exception($"Can not generate card of hand with text {handCard}");
        }

        Cards = GenerateCards(handCard);
        Spades = new TypeSuitCard(Cards, Suit.NameSpades);
        Clubs = new TypeSuitCard(Cards, Suit.NameClubs);
        Diamonds = new TypeSuitCard(Cards, Suit.NameDiamonds);
        Hearts = new TypeSuitCard(Cards, Suit.NameHearts);
        RankCards = new RankCard(Spades, Clubs, Diamonds, Hearts);
        OneCard = new OneCard(RankCards);
        DoubleCard = new DoubleCard(RankCards);
        TripleCard = new TripleCard(RankCards);
        QuadrupleCard = new QuadrupleCard(RankCards);
        Uuid = GenerateUuid();
    }

    /// <summary>
    /// Generate card from string input
    /// </summary>
    /// <param name="handCard"></param>
    /// <returns></returns>
    private List<Card> GenerateCards(string handCard)
    {
        var rawCard = new List<Card>();
        for (var i = 0; i < handCard.Length; i += 2)
        {
            var generateCard = GenerateCard(handCard[i], handCard[i + 1]);
            rawCard.Add(generateCard);
        }

        return rawCard.OrderBy(x => x.Rank.Index).ToList();
    }

    /// <summary>
    /// Generate card uuid
    /// </summary>
    /// <returns></returns>
    private string GenerateUuid()
    {
        var result = string.Empty;
        for (int i = 0; i < Setting.MaxNumberOfCardsOfUser; i++)
        {
            var rankCard = RankCards.RankCards[i];
            if (rankCard == null)
            {
                result += "0";
            }
            else
            {
                double index = 0;
                foreach (var card in rankCard)
                {
                    index += Math.Pow(2, card.Suit.Index); 
                }
                result += CardOfHand.ValidUuidCharacter[(int)index];
            }
        }

        return result;
    }

    /// <summary>
    /// Generate card from suit short name and rank name
    /// </summary>
    /// <param name="suitShortName"></param>
    /// <param name="rankName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private Card GenerateCard(char suitShortName, char rankName)
    {
        if (CardOfHand.ValidRankName.Contains(suitShortName) == false 
            || CardOfHand.ValidSuitShorName.Contains(rankName) == false)
        {
            throw new Exception($"Can not generate card with rank name {suitShortName} and suit short name {rankName}");
        }

        var indexOfRank = CardOfHand.ValidRankName.IndexOf(suitShortName);
        var indexOfSuit = CardOfHand.ValidSuitShorName.IndexOf(rankName);

        return new Card(indexOfRank, indexOfSuit);
    }
}
