using static System.Formats.Asn1.AsnWriter;

namespace pk_Application.Model;

public class StackFive
{
    public List<CardUnit> TotalCard { get; set; }
    public TypeEnum Type { get; set; }
    public double Score { get; set; }
    public override string ToString()
    {
        var result = Type.ToString();
        return result;
    }

    public StackFive(List<CardUnit> init)
    {
        TotalCard = init;
        var dividation = new UserCard(init);
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
                + dividation.OneCard[0].CardNumber * 13
                + +dividation.OneCard[1].CardNumber;
            return;
        }

        if (dividation.CoupleCard.Count > 2)
        {
            Type = TypeEnum.TwoCoupleCard;
            Score = dividation.CoupleCard[0].CardNumber * 13 * 13
                + dividation.CoupleCard[2].CardNumber * 13
                + dividation.OneCard[0].CardNumber;
            return;
        }

        if (dividation.CoupleCard.Count > 0)
        {
            Type = TypeEnum.CoupleCard;
            Score = dividation.CoupleCard[0].CardNumber * 13 * 13 * 13
                + dividation.OneCard[0].CardNumber * 13 * 13
                + dividation.OneCard[1].CardNumber * 13
                + dividation.OneCard[2].CardNumber;
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
