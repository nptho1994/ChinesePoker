using static System.Formats.Asn1.AsnWriter;

namespace pk_Application.Model;

public class StackThree
{
    public List<CardUnit> TotalCard { get; set; }
    public TypeEnum Type { get; set; }
    public double Score { get; set; }
    public string PokerDisplay { get; set; }
    public override string ToString()
    {
        var result = string.Empty;
        foreach (var item in TotalCard)
        {
            result += item.ToString() + "  ";
        }

        return result;
    }

    public StackThree(List<CardUnit> init)
    {
        TotalCard = init;
        var dividation = new UserCard(init);
        if (dividation.ThreeCard.Count > 0)
        {
            Type = TypeEnum.ThreeCard;
            Score = dividation.ThreeCard[0].CardNumber;
            return;
        }
        
        if (dividation.CoupleCard.Count > 0)
        {
            Type = TypeEnum.CoupleCard;
            Score = dividation.CoupleCard[0].CardNumber * 13
                + dividation.OneCard[0].CardNumber;
            return;
        }

        if (dividation.OneCard.Count == 3)
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
