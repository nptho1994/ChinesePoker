using pk_Application.Model.CardSetting;
using static pk_Application.Common.Constant;
using static pk_Application.Common.Constant.Config;

namespace pk_Application.Function;

public class SortPokerCard
{
    public List<Card> HandCard { get; set; }
    public CardSingle SingleCard { get; set; }
    public CardDouble DoubleCard { get; set; }
    public CardTriple TripleCard { get; set; }
    public CardQuadruple QuadrupleCard { get; set; }
    public RankCard RankCards { get; set; }
    public CardOfTypeSuit Spades { get; set; }
    public CardOfTypeSuit Clubs { get; set; }
    public CardOfTypeSuit Diamonds { get; set; }
    public CardOfTypeSuit Hearts { get; set; }
    public string Uuid { get; set; } = string.Empty;
    public SortPokerCard(List<Card> cards)
    {
        if (cards.Count != 13)
        {
            throw new Exception("The hand cards invalid");
        }

        HandCard = cards.OrderBy(x => x.Rank.Point).ThenBy(x => x.Suit.Index).ToList();
        PokerConfiguration(HandCard);
    }

    public void PokerConfiguration(List<Card> cardsAreSorted)
    {
        Spades = new CardOfTypeSuit(cardsAreSorted, Suit.NameSpades);
        Clubs = new CardOfTypeSuit(cardsAreSorted, Suit.NameClubs);
        Diamonds = new CardOfTypeSuit(cardsAreSorted, Suit.NameDiamonds);
        Hearts = new CardOfTypeSuit(cardsAreSorted, Suit.NameHearts);
        RankCards = new RankCard(Spades, Clubs, Diamonds, Hearts);
        SingleCard = new CardSingle(RankCards);
        DoubleCard = new CardDouble(RankCards);
        TripleCard = new CardTriple(RankCards);
        QuadrupleCard = new CardQuadruple(RankCards);
        Uuid = GeneratePokerUuid();        
    }

    private string GeneratePokerUuid()
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
}
