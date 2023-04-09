using static pk_Application.Common.Constant;

namespace pk_Application.Model.Card;

public class CardQuadruple
{
    public List<List<Card>?> RankCards { get; set; } = new List<List<Card>?>();
    public List<Card> RealCards { get; set; } = new List<Card>();
    public decimal Point { get; set; } = 0;

    /// <summary>
    /// Get quadruple card (the rank has double suit)
    /// </summary>
    /// <param name="rankCards"></param>
    public CardQuadruple(RankCard rankCards)
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
            Point += i;
        }
    }
}