using static pk_Application.Common.Constant;

namespace pk_Application.Model;

public class QuadrupleCard
{
    public List<List<Card>?> RankCards { get; set; } = new List<List<Card>?>();
    public List<Card> RealCards { get; set; } = new List<Card>();
    public double Point { get; set; } = 0;

    /// <summary>
    /// Get quadruple card (the rank has double suit)
    /// </summary>
    /// <param name="spades"></param>
    /// <param name="clubs"></param>
    /// <param name="diamonds"></param>
    /// <param name="hearts"></param>
    public QuadrupleCard(RankCard rankCards)
    {
        for (int i = 0; i < Setting.MaxNumberOfCardsOfUser; i++)
        {
            var rankCard = rankCards.RankCards[i];
            // Does not exist card for this rank or the suit of rank not equal 4
            if (rankCard == null || rankCard.Count != 4)
            {
                RankCards.Add(null);
                continue;
            }

            RealCards.AddRange(rankCard);
            Point += Math.Pow(2, i);
        }
    }
}