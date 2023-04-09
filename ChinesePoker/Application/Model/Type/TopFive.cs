//using pk_Application.Common;
//using pk_Application.Model.CardSetting;

//namespace pk_Application.Model.Type;

///// <summary>
///// Top of hand which has five cards
///// </summary>
//public class TopFive
//{
//    public string Name { get; set; } = string.Empty;
//    public decimal Score { get; set; } = 0;
//    public int Level { get; set; } = 0;
//    public decimal MinimumOfScore { get; set; } = 0;
//    public decimal MaximumOfScore { get; set; } = 0;
//    public CardOfTopFive CardOfTopFive { get; set; }

//    public TopFive(CardOfTopFive cards)
//    {
//        CardOfTopFive = cards;
//        var card = cards.Cards.FirstOrDefault();
//        if (card == null || cards.Cards.Count != 5)
//        {
//            throw new Exception("The stack top of poker is not valid");
//        }

//        if (cards.StraightCard.RealCards.Count == 5 &&
//            (
//                cards.Spades.RealCard.Count == 5
//                || cards.Clubs.RealCard.Count == 5
//                || cards.Diamonds.RealCard.Count == 5
//                || cards.Hearts.RealCard.Count == 5
//            ))
//        {
//            Name = Constant.StackSetting.TopFiveTypeSetting.NameOfRoyalFlush;
//            Score = GetScoreForQuadrupleCard(cards.Cards);
//            Level = Constant.StackSetting.TopFiveTypeSetting.RoyalFlush;
//            MinimumOfScore = Constant.StackSetting.TopFiveTypeSetting.NumberOfCaseRoyalFlush;
//            MaximumOfScore = MinimumOfScore + GetMaximumScoreForQuadrupleCard();
//            return;
//        }

//        if (cards.QuadrupleCard.RealCards.Count > 0)
//        {
//            Name = Constant.StackSetting.TopFiveTypeSetting.NameOfQuadruple;
//            Score = GetScoreForQuadrupleCard(cards.Cards);
//            Level = Constant.StackSetting.TopFiveTypeSetting.Quadruple;
//            MinimumOfScore = Constant.StackSetting.TopFiveTypeSetting.NumberOfCaseQuadruple;
//            MaximumOfScore = MinimumOfScore + GetMaximumScoreForQuadrupleCard();
//            return;
//        }

//        if (cards.TripleCard.RealCards.Count > 0 && cards.DoubleCard.RealCards.Count > 0)
//        {
//            Name = Constant.StackSetting.TopFiveTypeSetting.NameOfQuadruple;
//            Score = card.Rank.Point;
//            Level = Constant.StackSetting.TopFiveTypeSetting.Quadruple;
//            MinimumOfScore = Constant.StackSetting.TopFiveTypeSetting.NumberOfCaseQuadruple;
//            MaximumOfScore = MinimumOfScore + 13; // Has only 10 cases
//            return;
//        }

//        if (dividation.Spade.TotalCardNumber == 5
//            || dividation.Clover.TotalCardNumber == 5
//            || dividation.Diamonds.TotalCardNumber == 5
//            || dividation.Hearts.TotalCardNumber == 5)
//        {
//            double score = 0;
//            for (var i = 0; i < dividation.TotalUserCard.Count; i++)
//            {
//                score += Math.Pow(2, dividation.TotalUserCard[i].CardNumber);
//            }
//            Type = TypeEnum.Flush;
//            Score = score;
//            return;
//        }

//        if (dividation.Straight.Count >= 5)
//        {
//            double score = 0;
//            for (var i = 0; i < dividation.TotalUserCard.Count; i++)
//            {
//                score += Math.Pow(2, dividation.TotalUserCard[i].CardNumber);
//            }
//            Type = TypeEnum.Straight;
//            Score = score;
//            return;
//        }

//        if (dividation.ThreeCard.Count > 0 && dividation.OneCard.Count > 1)
//        {
//            Type = TypeEnum.ThreeCard;
//            Score = dividation.ThreeCard[0].CardNumber * 13 * 13
//                + dividation.OneCard[1].CardNumber * 13
//                + +dividation.OneCard[0].CardNumber;
//            return;
//        }

//        if (dividation.CoupleCard.Count > 2)
//        {
//            Type = TypeEnum.TwoCoupleCard;
//            Score = dividation.CoupleCard[2].CardNumber * 13 * 13
//                + dividation.CoupleCard[0].CardNumber * 13
//                + dividation.OneCard[0].CardNumber;
//            return;
//        }

//        if (dividation.CoupleCard.Count > 0)
//        {
//            Type = TypeEnum.CoupleCard;
//            Score = dividation.CoupleCard[0].CardNumber * 13 * 13 * 13
//                + dividation.OneCard[2].CardNumber * 13 * 13
//                + dividation.OneCard[1].CardNumber * 13
//                + dividation.OneCard[0].CardNumber;
//            return;
//        }

//        if (dividation.OneCard.Count == 5)
//        {
//            double score = 0;
//            for (var i = 0; i < dividation.OneCard.Count; i++)
//            {
//                score += Math.Pow(2, dividation.OneCard[i].CardNumber);
//            }
//            Type = TypeEnum.MaximumCard;
//            Score = score;
//        }

//        if (cards.StraightCard.RealCards.Count == 5 &&
//           (
//               cards.Spades.RealCard.Count == 5
//               || cards.Clubs.RealCard.Count == 5
//               || cards.Diamonds.RealCard.Count == 5
//               || cards.Hearts.RealCard.Count == 5
//           ))
//        {
//            Name = Constant.StackSetting.TopFiveTypeSetting.NameOfRoyalFlush;
//            Score = card.Rank.Point;
//            Level = Constant.StackSetting.TopFiveTypeSetting.RoyalFlush;
//            MinimumOfScore = Constant.StackSetting.TopFiveTypeSetting.NumberOfCaseRoyalFlush;
//            MaximumOfScore = MinimumOfScore + 10; // Has only 10 cases
//            return;
//        }
//    }

//    private decimal GetMinimumScoreForQuadrupleCard()
//    {
//        decimal score = 0;
//        var maxCardScore = Constant.StackSetting.TopFiveTypeSetting.NumberOfCaseMaxCard;

//        score += maxCardScore;
//        return score;
//    }

//    private decimal GetMaximumScoreForQuadrupleCard()
//    {
//        decimal count = 0;
//        for (var c1 = 1; c1 < 14; c1++)
//        {
//            for (var c2 = 1; c2 < 14; c2++)
//            {
//                if (c2 != c1)
//                {
//                    count++;
//                }
//            }
//        }

//        return count;
//    }

//    private decimal GetScoreForQuadrupleCard(List<Card> cards)
//    {
//        var quadCard = cards.FirstOrDefault();
//        var singleCard = cards.LastOrDefault();
//        if (cards == null || quadCard == null || singleCard == null || cards.Count != 5)
//        {
//            throw new Exception("The stack top of poker is not valid");
//        }
       
//        decimal count = 0;
//        // Card start with rank two and end with rank ace
//        for (var c1 = 1; c1 < quadCard.Rank.Point; c1++)
//        {
//            for (var c2 = 1; c2 < singleCard.Rank.Point; c2++)
//            {
//                if (c2 != c1)
//                {
//                    count++;
//                }
//            }
//        }

//        return count;
//    }
//}
