namespace pk_Application.Model;

public class StackOne
{
    public List<CardUnit> TotalCard { get; set; }
    public TypeEnum Type { get; set; }
    public double Score { get; set; }
    public string PokerDisplay { get; set; }

    public int GetNumberWinBetStactThree()
    {
        switch (Type)
        {
            case TypeEnum.MaximumCard:
            case TypeEnum.CoupleCard:
                return 1;
            case TypeEnum.ThreeCard:
                return 2;
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

    public StackOne(List<CardUnit> init)
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
