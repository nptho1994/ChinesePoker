using static pk_Application.Common.Constant;

namespace pk_Application.Model;

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
    public RankCard(TypeSuitCard spades, TypeSuitCard clubs, TypeSuitCard diamonds, TypeSuitCard hearts)
    {
        for (int i = 0; i < Setting.MaxNumberOfCardsOfUser; i++)
        {
            var rankCards = new List<Card?>();

            if (spades.Cards[i] != null)
            {
                rankCards.Add(spades.Cards[i]);
            }

            if (clubs.Cards[i] != null)
            {
                rankCards.Add(clubs.Cards[i]);
            }

            if (diamonds.Cards[i] != null)
            {
                rankCards.Add(diamonds.Cards[i]);
            }

            if (hearts.Cards[i] != null)
            {
                rankCards.Add(hearts.Cards[i]);
            }

            if (rankCards.Any() == false)
            {
                RankCards.Add(null);
                continue;
            }

            RankCards.Add(rankCards);
        }
    }
}