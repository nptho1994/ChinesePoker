using static pk_Application.Common.Constant;

namespace pk_Application.Model.CardSetting;

public class RankCard
{
    public List<List<Card>?> RankCards { get; set; } = new List<List<Card>?>();

    /// <summary>
    /// Get double card (the rank has double suit)
    /// </summary>
    /// <param name="spades"></param>
    /// <param name="clubs"></param>
    /// <param name="diamonds"></param>
    /// <param name="hearts"></param>
    public RankCard(CardOfTypeSuit spades, CardOfTypeSuit clubs, CardOfTypeSuit diamonds, CardOfTypeSuit hearts)
    {
        for (int i = 0; i < Setting.MaxNumberOfCardsOfUser; i++)
        {
            var rankCards = new List<Card>();

            var spade = spades.Cards[i];
            var club = clubs.Cards[i];
            var diamond = diamonds.Cards[i];
            var heart = hearts.Cards[i];
            if (spade != null)
            {
                rankCards.Add(spade);
            }

            if (club != null)
            {
                rankCards.Add(club);
            }

            if (diamond != null)
            {
                rankCards.Add(diamond);
            }

            if (heart != null)
            {
                rankCards.Add(heart);
            }

            if (rankCards == null || rankCards.Any() == false)
            {
                RankCards.Add(null);
                continue;
            }

            RankCards.Add(rankCards);
        }
    }
}