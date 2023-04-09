using static pk_Application.Common.Constant;

namespace pk_Application.Model.CardSetting;

public class CardTriple
{

    public List<List<Card>?> RankCards { get; set; } = new List<List<Card>?>();
    public List<Card> RealCards { get; set; } = new List<Card>();

    /// <summary>
    /// Get triple card (the rank has double suit)
    /// </summary>
    /// <param name="rankCards"></param>
    public CardTriple(RankCard rankCards)
    {
        for (int i = 0; i < Setting.MaxNumberOfCardsOfUser; i++)
        {
            var rankCard = rankCards.RankCards[i];
            // Does not exist card for this rank or the suit of rank not equal 3
            if (rankCard == null || rankCard.Count != 3)
            {
                RankCards.Add(null);
                continue;
            }

            RealCards.AddRange(rankCard);
        }
    }
}