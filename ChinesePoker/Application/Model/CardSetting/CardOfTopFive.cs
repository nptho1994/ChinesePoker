using static pk_Application.Common.Constant.Config;
using static pk_Application.Common.Constant;

namespace pk_Application.Model.CardSetting;

public class CardOfTopFive
{
    public List<Card> Cards { get; set; } = new List<Card>();
    public string Uuid { get; set; } = string.Empty;
    public string BestResult { get; set; } = string.Empty;
    public CardOfTypeSuit Spades { get; set; }
    public CardOfTypeSuit Clubs { get; set; }
    public CardOfTypeSuit Diamonds { get; set; }
    public CardOfTypeSuit Hearts { get; set; }
    public RankCard RankCards { get; set; }
    public CardStraight StraightCard { get; set; }
    public CardSingle OneCard { get; set; }
    public CardDouble DoubleCard { get; set; }
    public CardTriple TripleCard { get; set; }
    public CardQuadruple QuadrupleCard { get; set; }
    public string TypeOfTopFive { get; set; } = string.Empty;
    public decimal PointOfTopFive { get; set; }

    /// <summary>
    /// Gemerate card on hand with string input 
    /// Example: JHKD8H1S2C
    /// </summary>
    /// <param name="handCard"></param>
    /// <exception cref="Exception"></exception>
    public CardOfTopFive(string handCard)
    {
        if (string.IsNullOrWhiteSpace(handCard) || handCard.Length != 10)
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
    /// Example: JHKD8H1S2C
    /// </summary>
    /// <param name="handCard"></param>
    /// <exception cref="Exception"></exception>
    public CardOfTopFive(List<Card> handCard)
    {
        if (handCard == null || handCard.Count != 5)
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

    //public int GetNumberWinBetStactThree()
    //{
    //    switch (Type)
    //    {
    //        case TypeEnum.MaximumCard:
    //        case TypeEnum.CoupleCard:
    //        case TypeEnum.TwoCoupleCard:
    //        case TypeEnum.ThreeCard:
    //        case TypeEnum.Straight:
    //        case TypeEnum.Flush:
    //        case TypeEnum.Boat:
    //            return 1;
    //        case TypeEnum.Quad:
    //            return 4;
    //        case TypeEnum.StraightFlush:
    //            return 8;
    //        default:
    //            return 1;
    //    }
    //}

    //public override string ToString()
    //{
    //    var result = string.Empty;
    //    foreach (var item in TotalCard)
    //    {
    //        result += item.ToString() + "  ";
    //    }

    //    return result;
    //}

    //public void AnalysicTopFiveCard()
    //{
    //    if (StraightCard.RealCards.Count == 5 &&
    //        (Spades.RealCard.Count == 5
    //        || Clubs.RealCard.Count == 5
    //        || Diamonds.RealCard.Count == 5
    //        || Hearts.RealCard.Count == 5))
    //    {
    //        TypeOfTopFive = StackSetting.TopFiveTypeSetting.NameOfRoyalFlush;
    //        PointOfTopFive = StraightCard.PointStraight1;
    //        return;
    //    }

    //    if (QuadrupleCard.RealCards.Count > 0)
    //    {
    //        TypeOfTopFive = StackSetting.TopFiveTypeSetting.NameOfQuadruple;
    //        PointOfTopFive = QuadrupleCard.Point;
    //        return;
    //    }

    //    if (TripleCard.RealCards.Count > 0 && DoubleCard.RealCards.Count > 0)
    //    {
    //        TypeOfTopFive = StackSetting.TopFiveTypeSetting.NameOfBoat;
    //        PointOfTopFive = QuadrupleCard.Point;
    //        return;
    //    }

    //    if (dividation.Spade.TotalCardNumber == 5
    //        || dividation.Clover.TotalCardNumber == 5
    //        || dividation.Diamonds.TotalCardNumber == 5
    //        || dividation.Hearts.TotalCardNumber == 5)
    //    {
    //        double score = 0;
    //        for (var i = 0; i < dividation.TotalUserCard.Count; i++)
    //        {
    //            score += Math.Pow(2, dividation.TotalUserCard[i].CardNumber);
    //        }
    //        TypeOfTopFive =.Flush;
    //        Score = score;
    //        return;
    //    }

    //    if (dividation.Straight.Count >= 5)
    //    {
    //        double score = 0;
    //        for (var i = 0; i < dividation.TotalUserCard.Count; i++)
    //        {
    //            score += Math.Pow(2, dividation.TotalUserCard[i].CardNumber);
    //        }
    //        TypeOfTopFive =.Straight;
    //        Score = score;
    //        return;
    //    }

    //    if (dividation.ThreeCard.Count > 0 && dividation.OneCard.Count > 1)
    //    {
    //        TypeOfTopFive =.ThreeCard;
    //        Score = dividation.ThreeCard[0].CardNumber * 13 * 13
    //            + dividation.OneCard[1].CardNumber * 13
    //            + +dividation.OneCard[0].CardNumber;
    //        return;
    //    }

    //    if (dividation.CoupleCard.Count > 2)
    //    {
    //        TypeOfTopFive =.TwoCoupleCard;
    //        Score = dividation.CoupleCard[2].CardNumber * 13 * 13
    //            + dividation.CoupleCard[0].CardNumber * 13
    //            + dividation.OneCard[0].CardNumber;
    //        return;
    //    }

    //    if (dividation.CoupleCard.Count > 0)
    //    {
    //        TypeOfTopFive =.CoupleCard;
    //        Score = dividation.CoupleCard[0].CardNumber * 13 * 13 * 13
    //            + dividation.OneCard[2].CardNumber * 13 * 13
    //            + dividation.OneCard[1].CardNumber * 13
    //            + dividation.OneCard[0].CardNumber;
    //        return;
    //    }

    //    if (dividation.OneCard.Count == 5)
    //    {
    //        double score = 0;
    //        for (var i = 0; i < dividation.OneCard.Count; i++)
    //        {
    //            score += Math.Pow(2, dividation.OneCard[i].CardNumber);
    //        }
    //        TypeOfTopFive =.MaximumCard;
    //        Score = score;
    //    }
    //}
}
