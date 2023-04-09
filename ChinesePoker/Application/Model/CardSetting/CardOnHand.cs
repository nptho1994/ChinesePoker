using static pk_Application.Common.Constant;
using static pk_Application.Common.Constant.Config;

namespace pk_Application.Model.CardSetting;

public class CardOnHand
{
    public List<Card> Cards { get; set; } = new List<Card>();
    public string Uuid { get; set; } = string.Empty;
    public string BestResult { get; set; } = string.Empty;
    public CardOfTypeSuit Spades { get; set; }
    public CardOfTypeSuit Clubs { get; set; }
    public CardOfTypeSuit Diamonds { get; set; }
    public CardOfTypeSuit Hearts { get; set; }
    public RankCard RankCards { get; set; }
    public CardSingle OneCard { get; set; }
    public CardDouble DoubleCard { get; set; }
    public CardTriple TripleCard { get; set; }
    public CardQuadruple QuadrupleCard { get; set; }

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
        Spades = new CardOfTypeSuit(Cards, Suit.NameSpades);
        Clubs = new CardOfTypeSuit(Cards, Suit.NameClubs);
        Diamonds = new CardOfTypeSuit(Cards, Suit.NameDiamonds);
        Hearts = new CardOfTypeSuit(Cards, Suit.NameHearts);
        RankCards = new RankCard(Spades, Clubs, Diamonds, Hearts);
        OneCard = new CardSingle(RankCards);
        DoubleCard = new CardDouble(RankCards);
        TripleCard = new CardTriple(RankCards);
        QuadrupleCard = new CardQuadruple(RankCards);
        Uuid = GenerateUuid();
    }

    /// <summary>
    /// Gemerate card on hand with list card
    /// Example: JHKD8H1S2C2H5D5H7H1D9C9H4D3H
    /// </summary>
    /// <param name="handCard"></param>
    /// <exception cref="Exception"></exception>
    public CardOnHand(List<Card> handCard)
    {
        if (handCard == null || handCard.Count != 13)
        {
            var numberOfCard = handCard == null ? 0 : handCard.Count;
            throw new Exception($"Can not generate hand card from list card with {numberOfCard} cards");
        }

        Cards = handCard.OrderBy(x => x.Rank.Index).ThenBy(x => x.Suit.Index).ToList();
        Spades = new CardOfTypeSuit(Cards, Suit.NameSpades);
        Clubs = new CardOfTypeSuit(Cards, Suit.NameClubs);
        Diamonds = new CardOfTypeSuit(Cards, Suit.NameDiamonds);
        Hearts = new CardOfTypeSuit(Cards, Suit.NameHearts);
        RankCards = new RankCard(Spades, Clubs, Diamonds, Hearts);
        OneCard = new CardSingle(RankCards);
        DoubleCard = new CardDouble(RankCards);
        TripleCard = new CardTriple(RankCards);
        QuadrupleCard = new CardQuadruple(RankCards);
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
