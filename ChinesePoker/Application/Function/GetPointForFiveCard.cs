using pk_Application.Model.CardSetting;

namespace pk_Application.Function;

public class GetPointForFiveCard
{
    public decimal GetMinimumScoreForMaxCard()
    {
        decimal score = 0;
        return score;
    }

    public decimal GetMaximumScoreForMaxCard()
    {
        decimal score = 0;
        var maxCardScore = GetTotalCaseOfMaxCard();

        score += maxCardScore;
        return score;
    }

    public decimal GetTotalCaseOfMaxCard()
    {
        decimal count = 0;
        // Card start with rank two and end with rank ace
        for (var c1 = 1; c1 < 14; c1++)
        {
            for (var c2 = c1 + 1; c2 < 14; c2++)
            {
                for (var c3 = c2 + 1; c3 < 14; c3++)
                {
                    for (var c4 = c3 + 1; c4 < 14; c4++)
                    {
                        for (var c5 = c4 + 1; c5 < 14; c5++)
                        {
                            if (c2 - c1 > 1 || c3 - c2 > 1 || c4 - c3 > 1 || c5 - c4 > 1)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
        }

        return count;
    }

    public decimal GetScoreForMaxCard(List<Card> cards)
    {
        if (cards == null || cards.Count != 5)
        {
            throw new Exception("The stack top of poker is not valid");
        }
        decimal count = 0;
        // Card start with rank two and end with rank ace
        for (var c1 = 1; c1 < cards[0].Rank.Point; c1++)
        {
            for (var c2 = cards[0].Rank.Point + 1; c2 < cards[1].Rank.Point; c2++)
            {
                for (var c3 = cards[1].Rank.Point + 1; c3 < cards[2].Rank.Point; c3++)
                {
                    for (var c4 = cards[2].Rank.Point + 1; c4 < cards[3].Rank.Point; c4++)
                    {
                        for (var c5 = cards[3].Rank.Point + 1; c5 < cards[4].Rank.Point; c5++)
                        {
                            if (c2 - c1 > 1 || c3 - c2 > 1 || c4 - c3 > 1 || c5 - c4 > 1)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
        }

        return count;
    }
}
