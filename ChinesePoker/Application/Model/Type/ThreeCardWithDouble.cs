using pk_Application.Model.CardSetting;
using static pk_Application.Common.Constant.Config;
using static pk_Application.Common.Constant;
using static System.Net.Mime.MediaTypeNames;

namespace pk_Application.Model.Type;

public class ThreeCardWithDouble
{
    public List<Card> Cards { get; set; } = new List<Card>();
    public decimal Maximum { get; set; } = 0;
    public decimal Minimum { get; set; } = 0;
    public decimal Score { get; set; } = 0;
    public int Level { get; set; } = 0;

    /// <summary>
    /// ThreeCardDouble
    /// Maximum: The max score for this type. We will using this field to analysic and arrange poker
    /// Minimum:  The min score for this type. We will using this field to analysic and arrange poker
    /// Score: The score for this five cards. It is between Minimum and Maximum
    /// Level: Level of five card type. It is start by MaxFiveCard(levle 1) and end by RoyalFlush(level 9)
    /// </summary>
    /// <param name="FiveCard"></param>
    /// <exception cref="Exception"></exception>
    public ThreeCardWithDouble(List<Card> FiveCard)
    {
        if (FiveCard == null || FiveCard.Count != 3)
        {
            throw new Exception("Can not generate ThreeCardDouble");
        }

        Cards = FiveCard.OrderBy(x => x.Rank.Point).ToList();
        Level = 1;
        Minimum = StackSetting.ScoreSetting.MaxNumberOf3MaxCard + 1;
        Maximum = Minimum + GetMaximumScoreForThreeCardDouble();
        Score = GetScoreForThreeCardDouble();
    }

    /// <summary>
    /// Get basic info
    /// </summary>
    public ThreeCardWithDouble()
    {
        Minimum = StackSetting.ScoreSetting.MaxNumberOf3MaxCard + 1;
        Maximum = Minimum + GetMaximumScoreForThreeCardDouble();
    }

    /// <summary>
    /// Get maximum score for ThreeCardDouble
    /// </summary>
    /// <returns></returns>
    public decimal GetMaximumScoreForThreeCardDouble()
    {
        decimal score = 0;
        var maxCardScore = GetTotalCaseOfThreeCardDouble();

        score += maxCardScore;
        return score;
    }

    /// <summary>
    /// Generate total case for type ThreeCardDouble
    /// </summary>
    /// <returns></returns>
    public decimal GetTotalCaseOfThreeCardDouble()
    {
        decimal count = 0;
        var test = string.Empty;
        // Card start with rank two (point = 2) and end with rank ace (point = 14)
        for (var c1 = 2; c1 <= 14; c1++)
        {
            for (var c2 = 2; c2 <= 14; c2++)
            {
                if (c1 != c2)
                {
                    count++;
                    var tempCard = new List<Card>();
                    tempCard.Add(new Card(c1 - 1, 0));
                    tempCard.Add(new Card(c1 - 1, 1));
                    tempCard.Add(new Card(c2 - 1, 2));

                    test += CardOfHand.ValidRankName[tempCard[0].Rank.Index].ToString()
                        + CardOfHand.ValidRankName[tempCard[1].Rank.Index].ToString()
                        + CardOfHand.ValidRankName[tempCard[2].Rank.Index].ToString() + "\t"
                        + count + "\n";
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Get score from list card
    /// Count all case which has score less than this case
    /// </summary>
    /// <returns></returns>
    private decimal GetScoreForThreeCardDouble()
    {
        decimal count = 0;
        for (var c1 = 2; c1 <= Cards[2].Rank.Point; c1++)
        {
            for (var c2 = 2; c2 <= Cards[1].Rank.Point; c2++)
            {
                if (c1 != c2)
                {
                    count++;
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Generate total case for type ThreeCardDouble
    /// </summary>
    /// <returns></returns>
    public List<Card> GetCardsByScore(decimal score)
    {
        var result = new List<Card>();
        decimal count = 0;
        // Card start with rank two (point = 2) and end with rank ace (point = 14)
        for (var c1 = 2; c1 <= 14; c1++)
        {
            for (var c2 = 2; c2 <= 14; c2++)
            {
                if (c1 != c2)
                {
                    count++;
                    if (count == score)
                    {
                        result.Add(new Card(c1 - 1, 0));
                        result.Add(new Card(c1 - 1, 1));
                        result.Add(new Card(c2 - 1, 2));
                    }
                }
            }
        }

        return result;
    }
}
