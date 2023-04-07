namespace pk_Application.Model;

public class StackTwo
{
    public List<CardUnit> TotalCard { get; set; }
    public TypeEnum Type { get; set; }
    public double Score { get; set; }

    public int GetNumberWinBetStactThree()
    {
        switch (Type)
        {
            case TypeEnum.MaximumCard:
            case TypeEnum.CoupleCard:
            case TypeEnum.TwoCoupleCard:
            case TypeEnum.ThreeCard:
            case TypeEnum.Straight:
            case TypeEnum.Flush:
                return 1;
            case TypeEnum.Boat:
                return 2;
            case TypeEnum.Quad:
                return 4;
            case TypeEnum.StraightFlush:
                return 8;
            default:
                return 1;
        }
    }

    public override string ToString()
    {
        var result = string.Empty;
        foreach (var item in TotalCard)
        {
            result += item.ToString() + "  ";
        }

        return result;
    }

    public StackTwo(List<CardUnit> init)
    {
        TotalCard = init.OrderBy(x => x.CardNumber).ToList();
        var dividation = new UserCard(TotalCard);
        if (dividation.Straight.Count >= 5 &&
            (dividation.Spade.TotalCardNumber == 5
            || dividation.Clover.TotalCardNumber == 5
            || dividation.Diamonds.TotalCardNumber == 5
            || dividation.Hearts.TotalCardNumber == 5))
        {
            Type = TypeEnum.StraightFlush;
            Score = dividation.Straight[0].CardNumber;
            return;
        }

        if (dividation.FourCard.Count > 0)
        {
            Type = TypeEnum.Quad;
            Score = dividation.FourCard[0].CardNumber;
            return;
        }

        if (dividation.ThreeCard.Count > 0 && dividation.CoupleCard.Count > 0)
        {
            Type = TypeEnum.Boat;
            Score = dividation.ThreeCard[0].CardNumber * 13 + dividation.CoupleCard[0].CardNumber;
            return;
        }

        if (dividation.Spade.TotalCardNumber == 5
            || dividation.Clover.TotalCardNumber == 5
            || dividation.Diamonds.TotalCardNumber == 5
            || dividation.Hearts.TotalCardNumber == 5)
        {
            double score = 0;
            for (var i = 0; i < dividation.TotalUserCard.Count; i++)
            {
                score += Math.Pow(2, dividation.TotalUserCard[i].CardNumber);
            }
            Type = TypeEnum.Flush;
            Score = score;
            return;
        }

        if (dividation.Straight.Count >= 5)
        {
            double score = 0;
            for (var i = 0; i < dividation.TotalUserCard.Count; i++)
            {
                score += Math.Pow(2, dividation.TotalUserCard[i].CardNumber);
            }
            Type = TypeEnum.Straight;
            Score = score;
            return;
        }

        if (dividation.ThreeCard.Count > 0 && dividation.OneCard.Count > 1)
        {
            Type = TypeEnum.ThreeCard;
            Score = dividation.ThreeCard[0].CardNumber * 13 * 13
                + dividation.OneCard[1].CardNumber * 13
                + +dividation.OneCard[0].CardNumber;
            return;
        }

        if (dividation.CoupleCard.Count > 2)
        {
            Type = TypeEnum.TwoCoupleCard;
            Score = dividation.CoupleCard[2].CardNumber * 13 * 13
                + dividation.CoupleCard[0].CardNumber * 13
                + dividation.OneCard[0].CardNumber;
            return;
        }

        if (dividation.CoupleCard.Count > 0)
        {
            Type = TypeEnum.CoupleCard;
            Score = dividation.CoupleCard[0].CardNumber * 13 * 13 * 13
                + dividation.OneCard[2].CardNumber * 13 * 13
                + dividation.OneCard[1].CardNumber * 13
                + dividation.OneCard[0].CardNumber;
            return;
        }

        if (dividation.OneCard.Count == 5)
        {
            double score = 0;
            for(var i = 0; i < dividation.OneCard.Count; i++)
            {
                score += Math.Pow(2, dividation.OneCard[i].CardNumber);
            }
            Type = TypeEnum.MaximumCard;
            Score = score;
        }
    }
}
