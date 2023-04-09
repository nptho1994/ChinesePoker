using static pk_Application.Common.Constant;

namespace pk_Application.Model.CardSetting;

public class CardSingle
{
    public List<Card?> RankCards { get; set; } = new List<Card?>();
    public List<Card> RealCards { get; set; } = new List<Card>();

    /// <summary>
    /// Get single card (the rank has only one suit)
    /// </summary>
    /// <param name="rankCards"></param>
    public CardSingle(RankCard rankCards)
    {
        for (int i = 0; i < Setting.MaxNumberOfCardsOfUser; i++)
        {
            var rankCard = rankCards.RankCards[i];
            // Does not exist card for this rank or the suit of rank not equal `
            if (rankCard == null || rankCard.Count != 1)
            {
                RankCards.Add(null);
                continue;
            }

            RealCards.AddRange(rankCard);
        }
    }
}