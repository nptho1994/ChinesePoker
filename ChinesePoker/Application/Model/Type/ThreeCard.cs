using pk_Application.Model.CardSetting;
using static pk_Application.Common.Constant.Config;
using static pk_Application.Common.Constant;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace pk_Application.Model.Type;

public class ThreeCard
{
    public List<Card> Cards { get; set; } = new List<Card>();
    public decimal Maximum { get; set; } = 0;
    public decimal Minimum { get; set; } = 0;
    public decimal Score { get; set; } = 0;
    public int Level { get; set; } = 0;

    /// <summary>
    /// ThreeCard mean which has 3 card same rank and 2 single card
    /// Maximum: The max score for this type. We will using this field to analysic and arrange poker
    /// Minimum:  The min score for this type. We will using this field to analysic and arrange poker
    /// Score: The score for this five cards. It is between Minimum and Maximum
    /// Level: Level of five card type. It is start by MaxFiveCard(levle 1) and end by RoyalFlush(level 9)
    /// </summary>
    /// <param name="FiveCard"></param>
    /// <exception cref="Exception"></exception>
    public ThreeCard(List<Card> FiveCard)
    {
        if (FiveCard == null || FiveCard.Count != 5)
        {
            throw new Exception("Can not generate ThreeCard");
        }

        Cards = FiveCard.OrderBy(x => x.Rank.Point).ToList();
        Level = 1;
        Minimum = StackSetting.ScoreSetting.MaxNumberOfTwoDoubleCard + 1;
        Maximum = Minimum + GetMaximumScoreForThreeCard();
        Score = GetScoreForThreeCard();
    }

    /// <summary>
    /// Get basic info
    /// </summary>
    public ThreeCard()
    {
        Minimum = StackSetting.ScoreSetting.MaxNumberOfTwoDoubleCard + 1;
        Maximum = Minimum + GetMaximumScoreForThreeCard();
    }

    /// <summary>
    /// Get maximum score for ThreeCard
    /// </summary>
    /// <returns></returns>
    public decimal GetMaximumScoreForThreeCard()
    {
        decimal score = 0;
        var maxCardScore = GetTotalCaseOfThreeCard();

        score += maxCardScore;
        return score;
    }

    /// <summary>
    /// Generate total case for type ThreeCard
    /// </summary>
    /// <returns></returns>
    public decimal GetTotalCaseOfThreeCard()
    {
        decimal count = 0;
        var test = string.Empty;
        // Card start with rank two (point = 2) and end with rank ace (point = 14)
        for (var c1 = 2; c1 <= 14; c1++)
        {
            for (var c2 = 2; c2 <= 14; c2++)
            {
                for (var c3 = 2; c3 < c2; c3++)
                {
                    if (c1 != c2 && c1 != c3)
                    {
                        count++;
                        var tempCard = new List<Card>();
                        tempCard.Add(new Card(c1 - 1, 0));
                        tempCard.Add(new Card(c1 - 1, 1));
                        tempCard.Add(new Card(c1 - 1, 2));
                        tempCard.Add(new Card(c2 - 1, 3));
                        tempCard.Add(new Card(c3 - 1, 0));

                        test += CardOfHand.ValidRankName[tempCard[0].Rank.Index].ToString()
                            + CardOfHand.ValidRankName[tempCard[1].Rank.Index].ToString()
                            + CardOfHand.ValidRankName[tempCard[2].Rank.Index].ToString()
                            + CardOfHand.ValidRankName[tempCard[3].Rank.Index].ToString()
                            + CardOfHand.ValidRankName[tempCard[4].Rank.Index].ToString() + "\t"
                            + count + "\n";
                    }
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
    private decimal GetScoreForThreeCard()
    {
        decimal count = 0;
        for (var c1 = 2; c1 <= Cards[0].Rank.Point; c1++)
        {
            for (var c2 = 2 ; c2 <= Cards[3].Rank.Point; c2++)
            {
                for (var c3 = 2; c3 <= Cards[4].Rank.Point; c3++)
                {
                    if (c1 != c2 && c1 != c3 && c3 < c2)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Generate total case for type ThreeCard
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
                for (var c3 = 2; c3 <= c2; c3++)
                {
                    if (c1 != c2 && c1 != c3)
                    {
                        count++;
                        if (count == score)
                        {
                            result.Add(new Card(c1 - 1, 0));
                            result.Add(new Card(c1 - 1, 1));
                            result.Add(new Card(c2 - 1, 2));
                            result.Add(new Card(c2 - 1, 3));
                            result.Add(new Card(c3 - 1, 0));
                        }
                    }
                }
            }
        }

        return result;
    }
}
