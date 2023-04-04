using pk_Application.Common;

namespace pk_Application.Model;

public class TypeCard
{
    public List<CardUnit?> Collection { get; set; } = new List<CardUnit?>();
    public int TotalCardNumber { get; set; }
    public double PointOfCollection { get; set; }
    public List<CardUnit> RealCard { get; set; } = new List<CardUnit>();

    public TypeCard(List<CardUnit?> type)
    {
        TotalCardNumber = 0;
        PointOfCollection = 0;
        for (int i = 0; i < Constant.Setting.MaxNumberOfCardsOfUser; i++)
        {
            var card = type[i];
            if (card != null)
            {
                RealCard.Add(card);
                TotalCardNumber++;
                PointOfCollection += Math.Pow(2, card.CardNumber);
            }
            Collection.Add(card);
        }
    }
}
