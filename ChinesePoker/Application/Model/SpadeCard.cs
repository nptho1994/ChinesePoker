using static pk_Application.Common.Constant;

namespace pk_Application.Model;

public class TypeSuitCard
{
    public List<Card?> Cards { get; set; } = new List<Card?>();
    public double PointOf { get; set; }
    public List<Card> RealCard { get; set; } = new List<Card>();

    public TypeSuitCard(List<Card> handCards, string suitName)
    {
        for (int i = 0; i < Setting.MaxNumberOfCardsOfUser; i++)
        {
            var card = handCards[i];
            if (card != null && card.Suit.Name == suitName)
            {
                RealCard.Add(card);
                PointOf += Math.Pow(2, card.Rank.Point);
            }
            Cards.Add(card);
        }
    }
}